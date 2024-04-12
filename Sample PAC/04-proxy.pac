function webBypass(url, host) {
	return (
		shExpMatch(host, '*.googlevideo.com') || shExpMatch(host, 'googlevideo.com') ||
		shExpMatch(host, '*.nflxext.com') || shExpMatch(host, 'nflxext.com') ||
		shExpMatch(host, '*.nflxso.net') || shExpMatch(host, 'nflxso.net') ||
		shExpMatch(host, '*.nflxvideo.net') || shExpMatch(host, 'nflxvideo.net') ||
		shExpMatch(host, '*.wbx2.com') || shExpMatch(host, 'wbx2.com') ||
		shExpMatch(host, '*.webex.com') || shExpMatch(host, 'webex.com') ||
		shExpMatch(host, '*.windowsupdate.com') || shExpMatch(host, 'windowsupdate.com') ||
		shExpMatch(host, '*.zoom.us') || shExpMatch(host, 'zoom.us')
	);
}

function webAppBypass(url, host) {
	return (
		shExpMatch(host, '*.*.aadrm.com') || shExpMatch(host, '*.aadrm.com') ||
		shExpMatch(host, '*.*.activedirectory.windowsazure.com') || shExpMatch(host, '*.activedirectory.windowsazure.com') ||
		shExpMatch(host, '*.*.adhybridhealth.azure.com') || shExpMatch(host, '*.adhybridhealth.azure.com') ||
		shExpMatch(host, '*.*.aria.microsoft.com') || shExpMatch(host, '*.aria.microsoft.com') ||
		shExpMatch(host, '*.*.azurerms.com') || shExpMatch(host, '*.azurerms.com') ||
		shExpMatch(host, '*.*.blob.core.windows.net') || shExpMatch(host, '*.blob.core.windows.net') ||
		shExpMatch(host, '*.*.cloudapp.net') || shExpMatch(host, '*.cloudapp.net') ||
		shExpMatch(host, '*.*.helpshift.com') || shExpMatch(host, '*.helpshift.com') ||
		shExpMatch(host, '*.*.hockeyapp.net') || shExpMatch(host, '*.hockeyapp.net') ||
		shExpMatch(host, '*.*.localytics.com') || shExpMatch(host, '*.localytics.com') ||
		shExpMatch(host, '*.*.microsoft.com') || shExpMatch(host, '*.microsoft.com') ||
		shExpMatch(host, '*.*.microsoftonline-p.com') || shExpMatch(host, '*.microsoftonline-p.com') ||
		shExpMatch(host, '*.*.microsoftonline-p.net') || shExpMatch(host, '*.microsoftonline-p.net') ||
		shExpMatch(host, '*.*.microsoftonline.com') || shExpMatch(host, '*.microsoftonline.com') ||
		shExpMatch(host, '*.*.msecnd.net') || shExpMatch(host, '*.msecnd.net') ||
		shExpMatch(host, '*.*.msocdn.com') || shExpMatch(host, '*.msocdn.com') ||
		shExpMatch(host, '*.*.office.com') || shExpMatch(host, '*.office.com') ||
		shExpMatch(host, '*.*.office.net') || shExpMatch(host, '*.office.net') ||
		shExpMatch(host, '*.*.office365.com') || shExpMatch(host, '*.office365.com') ||
		shExpMatch(host, '*.*.onmicrosoft.com') || shExpMatch(host, '*.onmicrosoft.com') ||
		shExpMatch(host, '*.*.phonefactor.net') || shExpMatch(host, '*.phonefactor.net') ||
		shExpMatch(host, '*.*.portal.cloudappsecurity.com') || shExpMatch(host, '*.portal.cloudappsecurity.com') ||
		shExpMatch(host, '*.*.queue.core.windows.net') || shExpMatch(host, '*.queue.core.windows.net') ||
		shExpMatch(host, '*.*.servicebus.windows.net') || shExpMatch(host, '*.servicebus.windows.net') ||
		shExpMatch(host, '*.*.sharepointonline.com') || shExpMatch(host, '*.sharepointonline.com') ||
		shExpMatch(host, '*.*.staffhub.office.com') || shExpMatch(host, '*.staffhub.office.com') ||
		shExpMatch(host, '*.*.table.core.windows.net') || shExpMatch(host, '*.table.core.windows.net') ||
		shExpMatch(host, '*.*.windows.net') || shExpMatch(host, '*.windows.net') ||
		shExpMatch(host, '*.account.activedirectory.windowsazure.com') || shExpMatch(host, 'account.activedirectory.windowsazure.com') ||
		shExpMatch(host, '*.account.office.net') || shExpMatch(host, 'account.office.net') ||
		shExpMatch(host, '*.adminwebservice.microsoftonline.com') || shExpMatch(host, 'adminwebservice.microsoftonline.com') ||
		shExpMatch(host, '*.agent.office.net') || shExpMatch(host, 'agent.office.net') ||
		shExpMatch(host, '*.amp.azure.net') || shExpMatch(host, 'amp.azure.net') ||
		shExpMatch(host, '*.analytics.localytics.com') || shExpMatch(host, 'analytics.localytics.com') ||
		shExpMatch(host, '*.ap1-fasttrack.cloudapp.net') || shExpMatch(host, 'ap1-fasttrack.cloudapp.net') ||
		shExpMatch(host, '*.apc.delve.office.com') || shExpMatch(host, 'apc.delve.office.com') ||
		shExpMatch(host, '*.api.localytics.com') || shExpMatch(host, 'api.localytics.com') ||
		shExpMatch(host, '*.api.office.com') || shExpMatch(host, 'api.office.com') ||
		shExpMatch(host, '*.appsforoffice.microsoft.com') || shExpMatch(host, 'appsforoffice.microsoft.com') ||
		shExpMatch(host, '*.assets.onestore.ms') || shExpMatch(host, 'assets.onestore.ms') ||
		shExpMatch(host, '*.aus.delve.office.com') || shExpMatch(host, 'aus.delve.office.com') ||
		shExpMatch(host, '*.auth.gfx.ms') || shExpMatch(host, 'auth.gfx.ms') ||
		shExpMatch(host, '*.az826701.vo.msecnd.net') || shExpMatch(host, 'az826701.vo.msecnd.net') ||
		shExpMatch(host, '*.browser.pipe.aria.microsoft.com') || shExpMatch(host, 'browser.pipe.aria.microsoft.com') ||
		shExpMatch(host, '*.c.microsoft.com') || shExpMatch(host, 'c.microsoft.com') ||
		shExpMatch(host, '*.c1.microsoft.com') || shExpMatch(host, 'c1.microsoft.com') ||
		shExpMatch(host, '*.can.delve.office.com') || shExpMatch(host, 'can.delve.office.com') ||
		shExpMatch(host, '*.clientconfig.microsoftonline-p.net') || shExpMatch(host, 'clientconfig.microsoftonline-p.net') ||
		shExpMatch(host, '*.clientlog.portal.office.com') || shExpMatch(host, 'clientlog.portal.office.com') ||
		shExpMatch(host, '*.connect.facebook.net') || shExpMatch(host, 'connect.facebook.net') ||
		shExpMatch(host, '*.contentstorage.osi.office.net') || shExpMatch(host, 'contentstorage.osi.office.net') ||
		shExpMatch(host, '*.dc.applicationinsights.microsoft.com') || shExpMatch(host, 'dc.applicationinsights.microsoft.com') ||
		shExpMatch(host, '*.dc.services.visualstudio.com') || shExpMatch(host, 'dc.services.visualstudio.com') ||
		shExpMatch(host, '*.delve.office.com') || shExpMatch(host, 'delve.office.com') ||
		shExpMatch(host, '*.dgps.support.microsoft.com') || shExpMatch(host, 'dgps.support.microsoft.com') ||
		shExpMatch(host, '*.docs.microsoft.com') || shExpMatch(host, 'docs.microsoft.com') ||
		shExpMatch(host, '*.ea-000.forms.osi.office.net') || shExpMatch(host, 'ea-000.forms.osi.office.net') ||
		shExpMatch(host, '*.ecn.dev.virtualearth.net') || shExpMatch(host, 'ecn.dev.virtualearth.net') ||
		shExpMatch(host, '*.em1-fasttrack.cloudapp.net') || shExpMatch(host, 'em1-fasttrack.cloudapp.net') ||
		shExpMatch(host, '*.equivio.office.com') || shExpMatch(host, 'equivio.office.com') ||
		shExpMatch(host, '*.equivioprod*.cloudapp.net') || shExpMatch(host, 'equivioprod*.cloudapp.net') ||
		shExpMatch(host, '*.eur.delve.office.com') || shExpMatch(host, 'eur.delve.office.com') ||
		shExpMatch(host, '*.eus2-000.forms.osi.office.net') || shExpMatch(host, 'eus2-000.forms.osi.office.net') ||
		shExpMatch(host, '*.firstpartyapps.oaspapps.com') || shExpMatch(host, 'firstpartyapps.oaspapps.com') ||
		shExpMatch(host, '*.forms.microsoft.com') || shExpMatch(host, 'forms.microsoft.com') ||
		shExpMatch(host, '*.forms.office.com') || shExpMatch(host, 'forms.office.com') ||
		shExpMatch(host, '*.gbr.delve.office.com') || shExpMatch(host, 'gbr.delve.office.com') ||
		shExpMatch(host, '*.graph.windows.net') || shExpMatch(host, 'graph.windows.net') ||
		shExpMatch(host, '*.groupsapi-prod.outlookgroups.ms') || shExpMatch(host, 'groupsapi-prod.outlookgroups.ms') ||
		shExpMatch(host, '*.groupsapi2-prod.outlookgroups.ms') || shExpMatch(host, 'groupsapi2-prod.outlookgroups.ms') ||
		shExpMatch(host, '*.groupsapi3-prod.outlookgroups.ms') || shExpMatch(host, 'groupsapi3-prod.outlookgroups.ms') ||
		shExpMatch(host, '*.groupsapi4-prod.outlookgroups.ms') || shExpMatch(host, 'groupsapi4-prod.outlookgroups.ms') ||
		shExpMatch(host, '*.hip.microsoftonline-p.net') || shExpMatch(host, 'hip.microsoftonline-p.net') ||
		shExpMatch(host, '*.home.office.com') || shExpMatch(host, 'home.office.com') ||
		shExpMatch(host, '*.ind.delve.office.com') || shExpMatch(host, 'ind.delve.office.com') ||
		shExpMatch(host, '*.jpn.delve.office.com') || shExpMatch(host, 'jpn.delve.office.com') ||
		shExpMatch(host, '*.kor.delve.office.com') || shExpMatch(host, 'kor.delve.office.com') ||
		shExpMatch(host, '*.lam.delve.office.com') || shExpMatch(host, 'lam.delve.office.com') ||
		shExpMatch(host, '*.liverdcxstorage.blob.core.windowsazure.com') || shExpMatch(host, 'liverdcxstorage.blob.core.windowsazure.com') ||
		shExpMatch(host, '*.login.microsoftonline.com') || shExpMatch(host, 'login.microsoftonline.com') ||
		shExpMatch(host, '*.login.windows.net') || shExpMatch(host, 'login.windows.net') ||
		shExpMatch(host, '*.manage.office.com') || shExpMatch(host, 'manage.office.com') ||
		shExpMatch(host, '*.management.azure.com') || shExpMatch(host, 'management.azure.com') ||
		shExpMatch(host, '*.mem.gfx.ms') || shExpMatch(host, 'mem.gfx.ms') ||
		shExpMatch(host, '*.mscrl.microsoft.com') || shExpMatch(host, 'mscrl.microsoft.com') ||
		shExpMatch(host, '*.msdn.microsoft.com') || shExpMatch(host, 'msdn.microsoft.com') ||
		shExpMatch(host, '*.na1-fasttrack.cloudapp.net') || shExpMatch(host, 'na1-fasttrack.cloudapp.net') ||
		shExpMatch(host, '*.nam.delve.office.com') || shExpMatch(host, 'nam.delve.office.com') ||
		shExpMatch(host, '*.neu-000.forms.osi.office.net') || shExpMatch(host, 'neu-000.forms.osi.office.net') ||
		shExpMatch(host, '*.nexus.officeapps.live.com') || shExpMatch(host, 'nexus.officeapps.live.com') ||
		shExpMatch(host, '*.nexusrules.officeapps.live.com') || shExpMatch(host, 'nexusrules.officeapps.live.com') ||
		shExpMatch(host, '*.office365servicehealthcommunications.cloudapp.net') || shExpMatch(host, 'office365servicehealthcommunications.cloudapp.net') ||
		shExpMatch(host, '*.office365zoom.cloudapp.net') || shExpMatch(host, 'office365zoom.cloudapp.net') ||
		shExpMatch(host, '*.outlook.office365.com') || shExpMatch(host, 'outlook.office365.com') ||
		shExpMatch(host, '*.outlook.uservoice.com') || shExpMatch(host, 'outlook.uservoice.com') ||
		shExpMatch(host, '*.platform.linkedin.com') || shExpMatch(host, 'platform.linkedin.com') ||
		shExpMatch(host, '*.policykeyservice.dc.ad.msft.net') || shExpMatch(host, 'policykeyservice.dc.ad.msft.net') ||
		shExpMatch(host, '*.portal.microsoftonline.com') || shExpMatch(host, 'portal.microsoftonline.com') ||
		shExpMatch(host, '*.portal.office.com') || shExpMatch(host, 'portal.office.com') ||
		shExpMatch(host, '*.prod.firstpartyapps.oaspapps.com.akadns.net') || shExpMatch(host, 'prod.firstpartyapps.oaspapps.com.akadns.net') ||
		shExpMatch(host, '*.prod.msocdn.com') || shExpMatch(host, 'prod.msocdn.com') ||
		shExpMatch(host, '*.products.office.com') || shExpMatch(host, 'products.office.com') ||
		shExpMatch(host, '*.protection.office.com') || shExpMatch(host, 'protection.office.com') ||
		shExpMatch(host, '*.provisioningapi.microsoftonline.com') || shExpMatch(host, 'provisioningapi.microsoftonline.com') ||
		shExpMatch(host, '*.r1.res.office365.com') || shExpMatch(host, 'r1.res.office365.com') ||
		shExpMatch(host, '*.r4.res.office365.com') || shExpMatch(host, 'r4.res.office365.com') ||
		shExpMatch(host, '*.res.delve.office.com') || shExpMatch(host, 'res.delve.office.com') ||
		shExpMatch(host, '*.rink.hockeyapp.net') || shExpMatch(host, 'rink.hockeyapp.net') ||
		shExpMatch(host, '*.sdk.hockeyapp.net') || shExpMatch(host, 'sdk.hockeyapp.net') ||
		shExpMatch(host, '*.secure.aadcdn.microsoftonline-p.com') || shExpMatch(host, 'secure.aadcdn.microsoftonline-p.com') ||
		shExpMatch(host, '*.securescore.office.com') || shExpMatch(host, 'securescore.office.com') ||
		shExpMatch(host, '*.shellprod.msocdn.com') || shExpMatch(host, 'shellprod.msocdn.com') ||
		shExpMatch(host, '*.signup.microsoft.com') || shExpMatch(host, 'signup.microsoft.com') ||
		shExpMatch(host, '*.staffhub.ms') || shExpMatch(host, 'staffhub.ms') ||
		shExpMatch(host, '*.staffhub.office.com') || shExpMatch(host, 'staffhub.office.com') ||
		shExpMatch(host, '*.staffhub.uservoice.com') || shExpMatch(host, 'staffhub.uservoice.com') ||
		shExpMatch(host, '*.staffhubweb.azureedge.net') || shExpMatch(host, 'staffhubweb.azureedge.net') ||
		shExpMatch(host, '*.suite.office.net') || shExpMatch(host, 'suite.office.net') ||
		shExpMatch(host, '*.support.content.office.net') || shExpMatch(host, 'support.content.office.net') ||
		shExpMatch(host, '*.support.office.com') || shExpMatch(host, 'support.office.com') ||
		shExpMatch(host, '*.technet.microsoft.com') || shExpMatch(host, 'technet.microsoft.com') ||
		shExpMatch(host, '*.telemetry.remoteapp.windowsazure.com') || shExpMatch(host, 'telemetry.remoteapp.windowsazure.com') ||
		shExpMatch(host, '*.telemetryservice.firstpartyapps.oaspapps.com') || shExpMatch(host, 'telemetryservice.firstpartyapps.oaspapps.com') ||
		shExpMatch(host, '*.templates.office.com') || shExpMatch(host, 'templates.office.com') ||
		shExpMatch(host, '*.video.osi.office.net') || shExpMatch(host, 'video.osi.office.net') ||
		shExpMatch(host, '*.videocontent.osi.office.net') || shExpMatch(host, 'videocontent.osi.office.net') ||
		shExpMatch(host, '*.videoplayercdn.osi.office.net') || shExpMatch(host, 'videoplayercdn.osi.office.net') ||
		shExpMatch(host, '*.vortex.data.microsoft.com') || shExpMatch(host, 'vortex.data.microsoft.com') ||
		shExpMatch(host, '*.web.localytics.com') || shExpMatch(host, 'web.localytics.com') ||
		shExpMatch(host, '*.weu-000.forms.osi.office.net') || shExpMatch(host, 'weu-000.forms.osi.office.net') ||
		shExpMatch(host, '*.wus-000.forms.osi.office.net') || shExpMatch(host, 'wus-000.forms.osi.office.net') ||
		shExpMatch(host, '*.wus-firstpartyapps.oaspapps.com') || shExpMatch(host, 'wus-firstpartyapps.oaspapps.com') ||
		shExpMatch(host, '*.www.office.com') || shExpMatch(host, 'www.office.com') ||
		shExpMatch(host, '*.www.remoteapp.windowsazure.com') || shExpMatch(host, 'www.remoteapp.windowsazure.com') ||
		shExpMatch(host, '*.zoom-cs-prod*.cloudapp.net') || shExpMatch(host, 'zoom-cs-prod*.cloudapp.net')
	);
}

function FindProxyForURL(url, host)
{
    if (webAppBypass(url, host)) return "DIRECT";

    if (webBypass(url, host)) return "DIRECT";

    if (isPlainHostName(host))
        return "DIRECT";

    if (url.substring(0, 4) == "ftp:")
        return "DIRECT";

    if (isInNet(host, "10.0.0.0", "255.0.0.0")
        || isInNet(host, "172.16.0.0",  "255.240.0.0")
        || isInNet(host, "192.168.0.0", "255.255.0.0")
        || isInNet(host, "169.254.0.0", "255.255.0.0")
        || isInNet(host, "127.0.0.0", "255.0.0.0"))
        return "DIRECT";
        

    return "PROXY proxy1:8080; proxy2:8080; DIRECT";
}
