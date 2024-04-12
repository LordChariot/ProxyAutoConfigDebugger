// Automatic Proxy Configuration File
// Client IP Based Load Balancing 

function FindProxyForURL(url, host)
{
    //exclude local sites and exceptions
    if (isPlainHostName(host))
                return "DIRECT";                
    
    else if (dnsDomainIs(host, "localhost"))
                return "DIRECT";
    
    else if (dnsDomainIs(host, "mydomain.com") ||
             isInNet(host, "127.0.0.1", "255.255.255.255") ||
             isInNet(host, "192.168.0.0", "255.255.0.0") ||
             isInNet(host, "172.16.0.0", "255.240.0.0") ||
             isInNet(host, "10.0.0.0", "255.0.0.0"))
                 return "DIRECT";
    
    else if (dnsDomainIs(host, "domain1.com"))
                return "DIRECT";
    
    else if (dnsDomainIs(host, "domain2.gov"))
                return "DIRECT";
    
    else if (dnsDomainIs(host, "domain3.net"))
                return "DIRECT";
    else
		var myIp = myIpAddress();
		
		var ipBits = myIp.split(".");
		//__logMessage("ipBits: "+ipBits+"\n");
		
		var mySeg = parseInt(ipBits[3]);
		//__logMessage("mySeg: "+mySeg+"\n");	
		
		if((mySeg % 2) == 0)          //EVEN
		{
			return "PROXY proxy1:9090; PROXY proxy2:9090; DIRECT";
		}
		else  //ODD
	   {
			return "PROXY proxy2:9090; PROXY proxy1:9090; DIRECT";
	   }
}
