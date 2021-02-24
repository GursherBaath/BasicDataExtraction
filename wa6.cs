#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Bme121
{
    // Electronic Health Record (EHR)
	//Key Performance Indicators (KPI)
    
    class EhrKpiRecord
    {
        public string State                                { get; private set; }
        public string StateCode                            { get; private set; }
        public string CountyName                           { get; private set; }
        public string StateFips                            { get; private set; }
        public string CountyFips                           { get; private set; }
        public string Fips                                 { get; private set; }
        public string Period                               { get; private set; }
        public int?   NumProvidersSignedUp                 { get; private set; }
        public int?   NumPrimaryCareProvidersSignedUp      { get; private set; }
        public int?   NumProvidersGoLive                   { get; private set; }
        public int?   NumPrimaryCareProvidersGoLive        { get; private set; }
        public int?   NumProvidersMeaningfulUse            { get; private set; }
        public int?   NumPrimaryCareProvidersMeaningfulUse { get; private set; }
        
        public EhrKpiRecord
        (
            string state,
            string stateCode,
            string countyName,
            string stateFips,
            string countyFips,
            string fips,
            string period,
            int?   numProvidersSignedUp,
            int?   numPrimaryCareProvidersSignedUp,
            int?   numProvidersGoLive,
            int?   numPrimaryCareProvidersGoLive,
            int?   numProvidersMeaningfulUse,
            int?   numPrimaryCareProvidersMeaningfulUse
        )
        {
            State                                = state;        
            StateCode                            = stateCode;        
            CountyName                           = countyName;        
            StateFips                            = stateFips;        
            CountyFips                           = countyFips;        
            Fips                                 = fips;        
            Period                               = period;        
            NumProvidersSignedUp                 = numProvidersSignedUp;        
            NumPrimaryCareProvidersSignedUp      = numPrimaryCareProvidersSignedUp;        
            NumProvidersGoLive                   = numProvidersGoLive;        
            NumPrimaryCareProvidersGoLive        = numPrimaryCareProvidersGoLive;        
            NumProvidersMeaningfulUse            = numProvidersMeaningfulUse;        
            NumPrimaryCareProvidersMeaningfulUse = numPrimaryCareProvidersMeaningfulUse;       
        }
    }
    
    static class Program
    {
        static void Main( )
        {
            
            List< EhrKpiRecord > ehrKpiRecords = new List< EhrKpiRecord >( );
           
            
            const string path = "REC_KPI_County.csv";
            const FileMode mode = FileMode.Open;
            const FileAccess access = FileAccess.Read;
            
            using FileStream filaz = new FileStream (path, mode, access);
            using StreamReader readaz = new StreamReader (filaz);
            readaz.ReadLine();
            
            while (!readaz.EndOfStream )
            {
                string linaz = readaz.ReadLine()!;
                string[] parts = linaz.Split(',');
                for (int i = 0; i < 13; i++)
                {
                parts[i] = parts[i].Trim('\"');
                }
                
                int?[] theInts = new int?[6];
                for (int j = 7; j < 13; j++)
                {
                    if (parts[j] == "NA")
                        theInts[j-7] = null;
                    else
                        theInts[j-7] = int.Parse(parts[j]);
                }
                
                ehrKpiRecords.Add(new EhrKpiRecord(parts[0],parts[1],parts[2],
                parts[3],parts[4],parts[5],parts[6],theInts[0],theInts[1],theInts[2],
                theInts[3],theInts[4],theInts[5]));
                
            }
            
            WriteLine( "ehrKpiRecords.Count = {0:n0}", ehrKpiRecords.Count );
            
        }
    }
}
