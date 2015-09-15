<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TypeScriptDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/typescript">
        module Sayings {
            export class Greeter {
                greeting: string;
                constructor (message: string) {
                    this.greeting = message;
                }
                greet() {
                    return "Hello, " + this.greeting;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <script type="text/typescript">
        var greeter = new Sayings.Greeter('world');
        alert(greeter.greet());
    </script>
    <script type="text/javascript" src="/js/typescript.min.js"></script>
    <script type="text/javascript" src="/js/typescript.compile.min.js"></script>
</body>
</html>
