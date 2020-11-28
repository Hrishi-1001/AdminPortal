using AdminPortal.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AdminPortal.Repository
{
	public interface IInstalmentRepository
	{
		IList<Instalment> GetAll();
		IList<Instalment> GetByArea(string location);
		IList<Instalment> GetByIP(IPAddress ipAddress);
		IList<Instalment> GetInstalment(string ip, string location);
	}

	public class InstalmentRepository : IInstalmentRepository
	{
		readonly List<Instalment> Instalments;

		public InstalmentRepository(List<Instalment> instalments)
		{
			Instalments = instalments;
		}

		public IList<Instalment> GetAll()
		{
			return (from Instalment in Instalments
				   select Instalment).ToList();
		}

		public IList<Instalment> GetByArea(string location)
		{
			return (from Instalment in Instalments
				   where Instalment.Location.Contains(location)
				   select Instalment).ToList();
		}

		public IList<Instalment> GetByIP(IPAddress ipAddress)
		{
			return (from Instalment in Instalments
				   where Instalment.ID.ToString().Contains(ipAddress.ToString())
				   select Instalment).ToList();
		}

		public IList<Instalment> GetInstalment(string ip, string location)
		{
			return (from Instalment in Instalments
				   where Instalment.Location.Contains(location) && Instalment.ID.ToString().Contains(ip)
				   select Instalment).ToList();
		}

	}
}
