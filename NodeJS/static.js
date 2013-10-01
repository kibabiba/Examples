var http = require('http'),
static = require('node-static');

var folder = new(static.Server)('./public');

http.createServer(function (req, res) {
   folder.serve(req, res);
}).listen(8080);