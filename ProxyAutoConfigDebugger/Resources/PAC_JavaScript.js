function FindProxyForURL(url, host) {

    if (isPlainHostName(host))
        return "DIRECT";

    if (
        dnsDomainIs(host, 'domain.com') ||
        shExpMatch(host, '*.domain.com')
    )
        return "DIRECT";

    if (url.substring(0, 4) == "ftp:")
        return "DIRECT";

    if (
        isInNet(host, "127.0.0.0", "255.0.0.0") ||
        isInNet(host, "10.0.0.0", "255.0.0.0") ||
        isInNet(host, "172.16.0.0", "255.240.0.0") ||
        isInNet(host, "192.168.0.0", "255.255.0.0") ||
        isInNet(host, "169.254.0.0", "255.255.0.0")
    )
        return "DIRECT";

    return "PROXY proxy1:8080; DIRECT";
}

