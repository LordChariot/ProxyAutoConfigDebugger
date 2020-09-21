# Proxy Auto-Config Debugger
Editor/Debugger for testing Proxy Auto-Config files.

 ![Screenshot 1](/docs/ScreenShot_1.png)

Proxy Auto-Config Debugger is an interactive editor/debugger for Proxy Auto-Configuration (PAC) files. It lets you edit the JavaScript in the left pane, test, and see the results in the right pane.

## How it Works
- The left-pane Editor is using the ICSharpCode.TextEditor control to give you color syntax highlighting.
- The Microsoft.JScript component built into .NET checks for syntax errors in the JavaScript as you are editing.
- The right-pane Results uses the .NET WebBrowser control to actually execute the JavaScript when the Test button is clicked.



## Version History
- 1.0.1.0: Fixed bug with compiling JavaScript in the editor.
- 1.0.0.0: Initial version for release.

## Things to know
- This is a .NET 4.7.2 WinForms project. .NET 4.7.2 must be present on the PC running it.

- Always put 'var' in front of variable definitions in the PAC file.

- You can use the internal command, **__logMessages()** to display debugging statements. Of course, these are not valid in actual PAC files and should be removed prior to use.

Example:

```js
var s='This is a string';
__logMessage('s='+s+'\n');
```
  
Displays in output:

    s=This is a string

- If you use FindProxyForURL**Ex**(url, host), you  must change the name of the entry function to the same. 

- Auto IP tries to determine your actual source IP address when testing. When un-checked, you can specify an explicit source IPv4.

## Developers
Dependencies:
- NuGet package: ICSharpCode.TextEditor 3.2.1.6466
- NuGet package: ILMerge 3.0.41
    - Optional, but you will have to edit the Post-build events to remove it for the Release/Sign configurations
    - If using another version of ILMerge, change the path in the program's Post-build events
    - This is used to merge the ICSharpCode.TextEditor.dll into the main .exe to have a single executable and no satellite dlls.

The Sign configuration is optional. If you use it, edit the Post-build event to define the proper path to signtool.exe in both the program's and the setup's projects. 

To build the Sign Setup .MSI, first build the Sign ProxyAutoConfigDebugger project, then build the Setup.

## License
ProxyAutoConfigDebugger: MIT License

ICSharpCode.TextEditor: GNU Lesser General Public License version 2.1

ILMerge: MIT License

Portions based on Mozilla using the Mozilla Public - License, v. 2.0.

Portions based on Chromium under BSD-Style License

Read LICENSE.txt

## Contact
For assistance with this program, contact lordchariot@lordchariot.com

