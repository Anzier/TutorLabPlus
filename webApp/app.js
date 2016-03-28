var express 		    = require('express')
	// , exphbs			= require('express-handlebars')
	, path				= require('path')
  , port  	   			= 3000
  , request				= require('request')
  , bodyParser			= require('body-parser')
  , indexRoutes			= require('./routes/index')
  , jade                = require('jade')

var app = express();

app.set('view engine', 'jade');
app.use(express.static(path.join(__dirname, 'public')));
app.use(bodyParser.urlencoded({ extended: false}))
app.use('/',indexRoutes)


app.listen(3000, function(){
	console.log("Listening on port 3000")
})
