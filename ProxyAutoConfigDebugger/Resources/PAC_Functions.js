var arguments;
//----mine
function FindProxyForURL(host, url) { }
function FindProxyForURLEx(host, url) { }
function __FindProxyForURL(host, url) {
    __clearMessages();
    __logMessage('<b>FindProxyForURL(' + host + ', ' + url + '):</b><br/>Starting...\n');
    var startTime = new Date();
    try {
        var result = FindProxyForURL(host, url);
        document.getElementById("result").innerHTML = '<b>' + result + '</b>';
        __logMessage('Return: <b>' + result + '</b>\r\n');
        __logMessage('<span style="font-size:11px;">Elapsed: <b style="color:blue;">' + (new Date() - startTime) + '</b> milliseconds</span>\r\n');
        return result;
    }
    catch (e) {
        __logMessage('\r\nException: FindProxyForURL(' + host + ', ' + url + '): \r\n' + e + '\r\n');
    }
}
function __FindProxyForURLEx(host, url) {
    __clearMessages();
    __logMessage('<b>FindProxyForURLEx(' + host + ', ' + url + '):</b> Starting...\r\n');
    var startTime = new Date();
    try {
        var result = FindProxyForURLEx(host, url);
        document.getElementById("result").innerHTML = '<b>' + result + '</b>';
        __logMessage('Return: <b>' + result + '</b>\r\n');
        __logMessage('<span style="font-size:11px;">Elapsed: <b style="color:blue;">' + (new Date() - startTime) + '</b> milliseconds</span>\r\n');
        return result;
    }
    catch (e) {
        __logMessage('\r\nException: FindProxyForURLEx(' + host + ', ' + url + '): \r\n' + e + '\r\n');
    }
};
function __logMessage(message) {
    document.getElementById("messages").innerHTML += message;
    window.external.LogMessageFromPac(message)
}
function __clearMessages() {
    document.getElementById("messages").innerHTML = '';
}

//---- adapted from Mozilla/Chrome source 
//dxr.mozilla.org/mozilla-central/source/netwerk/base/ProxyAutoConfig.cpp
//chromium.googlesource.com/chromium/src/+/master/net/proxy_resolution/pac_js_library.h
var months = { JAN: 0, FEB: 1, MAR: 2, APR: 3, MAY: 4, JUN: 5, JUL: 6, AUG: 7, SEP: 8, OCT: 9, NOV: 10, DEC: 11 }
var wdays = { SUN: 0, MON: 1, TUE: 2, WED: 3, THU: 4, FRI: 5, SAT: 6 };
function alert(message) {
    __logMessage(' alert(): <b style="color:blue">' + message + '</b>\r\n');
}
function dateRange() {
    var argsList = [].slice.call(arguments);
    function getMonth(name) {
        if (name in months) {
            return months[name];
        }
        return -1;
    }
    var date = new Date();
    var argc = arguments.length;
    var result = false;
    if (argc < 1) {
        __logMessage(' dateRange(' + argsList + '): false\r\n');
        return false;
    }
    var isGMT = (arguments[argc - 1] == 'GMT');

    if (isGMT) {
        argc--;
    }

    // function will work even without explict handling of this case     
    if (argc == 1) {
        var tmp = parseInt(arguments[0]);
        if (isNaN(tmp)) {
            result = ((isGMT ? date.getUTCMonth() : date.getMonth()) == getMonth(arguments[0]));
            if (result)
                __logMessage('<b style="color:green"> dateRange(' + argsList + '): true</b>\r\n');
            else
                __logMessage(' dateRange(' + argsList + '): false\r\n');
            return result;

            return result;
        } else if (tmp < 32) {
            result = ((isGMT ? date.getUTCDate() : date.getDate()) == tmp);
            if (result)
                __logMessage('<b style="color:green"> dateRange(' + argsList + '): true</b>\r\n');
            else
                __logMessage(' dateRange(' + argsList + '): false\r\n');
            return result;
        } else {
            result = ((isGMT ? date.getUTCFullYear() : date.getFullYear()) == tmp);
            if (result)
                __logMessage('<b style="color:green"> dateRange(' + argsList + '): true</b>\r\n');
            else
                __logMessage(' dateRange(' + argsList + '): false\r\n');
            return result;
        }
    }
    var year = date.getFullYear();
    var date1, date2;
    date1 = new Date(year, 0, 1, 0, 0, 0);
    date2 = new Date(year, 11, 31, 23, 59, 59);
    var adjustMonth = false;
    for (var i = 0; i < (argc >> 1); i++) {
        var tmp = parseInt(arguments[i]);
        if (isNaN(tmp)) {
            var mon = getMonth(arguments[i]);
            date1.setMonth(mon);
        } else if (tmp < 32) {
            adjustMonth = (argc <= 2);
            date1.setDate(tmp);
        } else {
            date1.setFullYear(tmp);
        }
    }
    for (var i = (argc >> 1); i < argc; i++) {
        var tmp = parseInt(arguments[i]);
        if (isNaN(tmp)) {
            var mon = getMonth(arguments[i]);
            date2.setMonth(mon);
        } else if (tmp < 32) {
            date2.setDate(tmp);
        } else {
            date2.setFullYear(tmp);
        }
    }
    if (adjustMonth) {
        date1.setMonth(date.getMonth());
        date2.setMonth(date.getMonth());
    }
    if (isGMT) {
        var tmp = date;
        tmp.setFullYear(date.getUTCFullYear());
        tmp.setMonth(date.getUTCMonth());
        tmp.setDate(date.getUTCDate());
        tmp.setHours(date.getUTCHours());
        tmp.setMinutes(date.getUTCMinutes());
        tmp.setSeconds(date.getUTCSeconds());
        date = tmp;
    }

    result = (date1 <= date2) ? (date1 <= date) && (date <= date2) : (date2 >= date) || (date >= date1);
    if (result)
        __logMessage('<b style="color:green"> dateRange(' + argsList + '): true</b>\r\n');
    else
        __logMessage(' dateRange(' + argsList + '): false\r\n');
    return result;
}
function dnsDomainIs(host, domain) {
    var result = (host.length >= domain.length &&
        host.substring(host.length - domain.length) == domain);
    if (result)
        __logMessage('<b style="color:green;"> dnsDomainIs(' + host + ', ' + domain + '): true</b>\r\n');
    else
        __logMessage(' dnsDomainIs(' + host + ', ' + domain + '): false\r\n');
    return result;
}
function dnsDomainLevels(host) {
    var results = host.split('.').length - 1;
    __logMessage(' dnsDomainLevels(' + host + '): <b style="color:blue;">' + results + '</b>\r\n');
    return results;
}
function isPlainHostName(host) {
    var result = (host.indexOf('.') == -1 ? true : false);
    if (result) {
        __logMessage('<b style="color:green;"> isPlainHostName(' + host + '): ' + result + '</b>\r\n')
    } else {
        __logMessage(' isPlainHostName(' + host + '):' + result + '\r\n')
    }
    return result;
}
function isValidIpAddress(ipchars) {
    //helper
    var matches = /^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$/.exec(ipchars);
    if (matches == null) {
        //__logMessage(' isValidIpAddress(' + ipchars + '):  false\r\n');
        return false;
    } else if (matches[1] > 255 || matches[2] > 255 || matches[3] > 255 || matches[4] > 255) {
        //__logMessage(' isValidIpAddress(' + ipchars + '):  false\r\n');
        return false;
    }
    //__logMessage('<b style="color:green;"> isValidIpAddress(' + ipchars + '): true</b>\r\n');
    return true;
}
function convert_addr(ipchars) {
    //helper
    var bytes = ipchars.split('.');
    var result = ((bytes[0] & 0xff) << 24) |
        ((bytes[1] & 0xff) << 16) |
        ((bytes[2] & 0xff) << 8) |
        (bytes[3] & 0xff);
    return result;
}
function isInNet(ipaddr, pattern, mask) {
    if (!isValidIpAddress(pattern) || !isValidIpAddress(mask)) {
        __logMessage(' isInNet(' + ipaddr + ', ' + pattern + ', ' + mask + '): false\r\n')
        return false;
    }
    if (!isValidIpAddress(ipaddr)) {
        ipaddr = dnsResolve(ipaddr);
        if (ipaddr == null) {
            __logMessage(' isInNet(' + ipaddr + ', ' + pattern + ', ' + mask + '): false\r\n')
            return false;
        }
    }
    var host = convert_addr(ipaddr);
    var pat = convert_addr(pattern);
    var msk = convert_addr(mask);
    var result = ((host & msk) == (pat & msk));
    if (result)
        __logMessage('<b style="color:green;"> isInNet(' + ipaddr + ', ' + pattern + ', ' + mask + '): true</b>\r\n');
    else
        __logMessage(' isInNet(' + ipaddr + ', ' + pattern + ', ' + mask + '): false\r\n');
    return result;
}
function localHostOrDomainIs(host, hostdom) {
    var result = (host.toLowerCase() == hostdom.toLowerCase()) ||
        (hostdom.toLowerCase().lastIndexOf(host.toLowerCase() + '.', 0) == 0);
    if (result) {
        __logMessage('<b style="color:green;"> localHostOrDomainIs(' + host + ',' + hostdom + '): ' + result + '</b>\r\n')
    } else {
        __logMessage(' localHostOrDomainIs(' + host + ',' + hostdom + '): ' + result + '\r\n')
    }
    return result;
}
function shExpMatch(url, pattern) {
    var opattern = pattern;
    pattern = pattern.replace(/\./g, '\\\.');
    pattern = pattern.replace(/\*/g, '.*');
    pattern = pattern.replace(/\?/g, '.');
    var newRe = new RegExp('^' + pattern + '$');
    var result = newRe.test(url);
    if (result)
        __logMessage('<b style="color:green;"> shExpMatch(' + url + ', ' + opattern + '): true</b>\r\n')
    else
        __logMessage(' shExpMatch(' + url + ', ' + opattern + '): false\r\n')
    return result;
}
function timeRange() {
    var argsList = [].slice.call(arguments);
    var argc = arguments.length;
    var date = new Date();
    var isGMT = false;
    var result = false;
    if (argc < 1) {
        __logMessage(' timeRange(' + argsList + '): false\r\n');
        return false;
    }
    if (arguments[argc - 1] == 'GMT') {
        isGMT = true;
        argc--;
    }

    var hour = isGMT ? date.getUTCHours() : date.getHours();
    var date1, date2;
    date1 = new Date();
    date2 = new Date();

    if (argc == 1) {
        result = (hour == arguments[0]);
        if (result)
            __logMessage('<b style="color:green"> timeRange(' + argsList + '): true</b>\r\n');
        else
            __logMessage(' timeRange(' + argsList + '): false\r\n');
        return result;
    } else if (argc == 2) {
        result = ((arguments[0] <= hour) && (hour <= arguments[1]));
        if (result)
            __logMessage('<b style="color:green"> timeRange(' + argsList + '): true</b>\r\n');
        else
            __logMessage(' timeRange(' + argsList + '): false\r\n');
        return result;
    } else {
        switch (argc) {
            case 6:
                date1.setSeconds(arguments[2]);
                date2.setSeconds(arguments[5]);
            case 4:
                var middle = argc >> 1;
                date1.setHours(arguments[0]);
                date1.setMinutes(arguments[1]);
                date2.setHours(arguments[middle]);
                date2.setMinutes(arguments[middle + 1]);
                if (middle == 2) {
                    date2.setSeconds(59);
                }
                break;
            default:
                throw 'timeRange: bad number of arguments'
        }
    }

    if (isGMT) {
        date.setFullYear(date.getUTCFullYear());
        date.setMonth(date.getUTCMonth());
        date.setDate(date.getUTCDate());
        date.setHours(date.getUTCHours());
        date.setMinutes(date.getUTCMinutes());
        date.setSeconds(date.getUTCSeconds());
    }
    result = (date1 <= date2) ? (date1 <= date) && (date <= date2) : (date2 >= date) || (date >= date1);
    if (result)
        __logMessage('<b style="color:green"> timeRange(' + argsList + '): true</b>\r\n');
    else
        __logMessage(' timeRange(' + argsList + '): false\r\n');
    return result;
}
function weekdayRange() {
    var argsList = [].slice.call(arguments);
    function getDay(weekday) {
        if (weekday in wdays) {
            return wdays[weekday];
        }
        return -1;
    }
    var date = new Date();
    var argc = arguments.length;
    var wday;
    if (argc < 1) {
        __logMessage(' weekdayRange(' + argsList + '): false\r\n');
        return false;
    }
    if (arguments[argc - 1] == 'GMT') {
        argc--;
        wday = date.getUTCDay();
    } else {
        wday = date.getDay();
    }
    var wd1 = getDay(arguments[0]);
    var wd2 = (argc == 2) ? getDay(arguments[1]) : wd1;
    var result = (wd1 == -1 || wd2 == -1) ? false : (wd1 <= wd2) ? (wd1 <= wday && wday <= wd2) : (wd2 >= wday || wday >= wd1);
    if (result)
        __logMessage('<b style="color:green"> weekdayRange(' + argsList + '): true</b>\r\n');
    else
        __logMessage(' weekdayRange(' + argsList + '): false\r\n');
    return result;
}

//---- window.external.X() functions
function dnsResolve(host) {
    var result = window.external.DnsResolve(host);
    if (result)
        __logMessage(' dnsResolve(' + host + '): <b style="color:blue;">' + result + '</b>\r\n');
    else
        __logMessage(' dnsResolve(' + host + '): ' + result + '\r\n');
    return result;
}
function isResolvable(host) {
    var result = window.external.IsResolvable(host);
    if (result) {
        __logMessage('<b style="color:green;"> isResolvable(' + host + '): ' + result + '</b>\r\n')
        return true;
    } else {
        __logMessage(' isResolvable(' + host + '): ' + result + '\r\n')
        return false;
    }
}
function myIpAddress() {
    var result = window.external.MyIpAddress();
    __logMessage(' myIpAddress(): <b style="color:blue">' + result + '</b>\r\n');
    return result;
}

//---- This is a Microsoft extension to PAC for IPv6
//docs.microsoft.com/en-us/windows/desktop/WinHttp/ipv6-extensions-to-navigator-auto-config-file-format
function dnsResolveEx(host) {
    var result = window.external.DnsResolveEx(host);
    __logMessage(' dnsResolveEx(' + host + '): <b style="color:blue">' + result + '</b>\r\n');
    return result;
}
function getClientVersion() {
    __logMessage(' getClientVersion(): <b style="color:blue">1.0</b>\r\n');
    return "1.0";
}
function isInNetEx(ipaddr, ipprefix) {
    var result = window.external.IsInNetEx(ipaddr, ipprefix);
    if (result)
        __logMessage('<b style="color:green;"> isInNetEx(' + ipaddr + ', ' + ipprefix + '): true</b>\r\n');
    else
        __logMessage(' isInNetEx(' + ipaddr + ', ' + ipprefix + '): false\r\n');
    return false;
}
function isResolvableEx(host) {
    var result = window.external.IsResolvableEx(host);
    __logMessage(' isResolvableEx(' + host + '): <b style="color:blue">' + result + '</b>\r\n');
    return result;
}
function myIpAddressEx() {
    var result = window.external.MyIpAddressEx();
    __logMessage(' myIpAddressEx(): <b style="color:blue">' + result + '</b>\r\n');
    return result;
}
function sortIpAddressList(ipAddressList) {
    var result = window.external.SortIpAddressList(ipAddressList);
    __logMessage(' sortIpAddressList(' + ipAddressList + '):\r\n<b style="color:blue">' + result.split(';').join(';\r\n') + '</b>\r\n');
    return result;
}
