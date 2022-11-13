using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using RaporlamaConsumer.Models.Entity;

namespace RaporlamaConsumer.Class
{
	public class RaporlamaConsumerService : IHostedService
	{
		private readonly string topic = "Raporlama";
		private readonly string groupId = "Raporlama_Group";
		private readonly string bootstrapServers = "localhost:9092";

		public Task StartAsync(CancellationToken cancellationToken)
		{
			var config = new ConsumerConfig
			{
				BootstrapServers = bootstrapServers,
				GroupId = groupId,
				AutoOffsetReset = AutoOffsetReset.Earliest
			};
			try
			{
				 
				using(var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
				{
					consumerBuilder.Subscribe(topic);
					var cancelToken = new CancellationTokenSource();

					try
					{
						while (true)
						{
							var consumer = consumerBuilder.Consume(cancelToken.Token);
							var raporRequest = JsonSerializer.Deserialize<Raporlama>(consumer.Message.Value);
							 raporRequest = consumer.Message.Value!=null?( JsonSerializer.Deserialize<Raporlama>(consumer.Message.Value)): JsonSerializer.Deserialize<Raporlama>(Stream.Null);
							//var raporRequest = JsonSerializer.Deserialize<Raporlama>(consumer.Message.Value);

							Debug.WriteLine($"Konum: {raporRequest.Konum} Kişi Sayısı: {raporRequest.KisiSayisi} Telefon Numarası Sayısı: {raporRequest.TelefonNumarasiSayisi} Raporlama Tarihi: {raporRequest.RaporlamaTalepTarihi.ToString()} ");
						}
					}
					catch (OperationCanceledException)
					{
						consumerBuilder.Close();
					}
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}

