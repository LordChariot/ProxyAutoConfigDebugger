
function FindProxyForURL(url, host) {
    var PROXYLIST = "PROXY 10.0.80.80:8080; PROXY 10.0.80.81:8080; DIRECT";
    var CLIENTIP = myIpAddress();

    // Direct connection for localhost, internal IP and domain names:
    if (
     isPlainHostName(host) || 
     host == "localhost" || 
     shExpMatch(host, "localhost.*") || 
     host == "127.0.0.1"
    )
    { return "DIRECT"; }

    if (
     shExpMatch(host, "*.local") ||
     shExpMatch(host, "*.mydomain.com") ||
     shExpMatch(host, "*.example.com") ||
     isInNet(host, "192.168.0.0", "255.255.0.0") ||
     isInNet(host, "172.16.0.0", "255.240.0.0") ||
     isInNet(host, "10.0.0.0", "255.0.0.0")
    )
    { return "DIRECT"; }

    // All other sites use the proxy servers, and return Direct if none are available
    return PROXYLIST;
}

