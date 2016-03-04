var express 		    = require('express')
	// , exphbs			= require('express-handlebars')
	, path				= require('path')
  , port  	   			= 3000
  , request				= require('request')
  , bodyParser			= require('body-parser')
  , indexRoutes			= require('./routes/index')
  , MongoClient         = require('mongodb').MongoClient
  , db                  = require('./db')
  , Users               = require('./models/users')
  , jade                = require('jade')
var app = express();



// app.engine('handlebars', exphbs({defaultLayout: 'base'}));
app.set('view engine', 'jade');
app.use(express.static(path.join(__dirname, 'public')));
app.use(bodyParser.urlencoded({ extended: false}))
app.use('/',indexRoutes)


app.listen(3000, function(){
	console.log("Listening on port 3000")
})

//using db if we wanted
// db.connect('mongodb://dbuser:password@ds063134.mongolab.com:63134/gramtracker', function(err){
//   if(err) {
//     console.log('Unable to connect to Mongo')
//     process.exit(1)
//   } else {
//     app.listen(3000, function() {
//       console.log('Listening on port 3000')
//     })
//   }
// })
