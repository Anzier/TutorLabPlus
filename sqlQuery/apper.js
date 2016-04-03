var express = require('express');
var bodyParser = require('body-parser');
var request = require('request');
var session = require('express-session');
var router = express.Router();
var mysql = require('mysql');
var http = require('http');

var connection = mysql.createConnection({
  host    : 'se3450.cl7tq4md0ynb.us-west-1.rds.amazonaws.com',
  user    : 'Mach5',
  password: 'DarthVader',
  port    : '3306',
  database: 'se3450'
})

console.log("should be connecting")

http.createServer(function (request, response) 
{ 
        console.log('Creating the http server');
        connection.query('SELECT * FROM studentSessions', function(err, rows, fields)
        {
                console.log('Connection result error '+err);
                console.log('numer of records is '+rows.length);
                response.writeHead(200, { 'Content-Type': 'application/json'});
                response.end(JSON.stringify(rows));
                response.end();
        }); 

}).listen(3000);