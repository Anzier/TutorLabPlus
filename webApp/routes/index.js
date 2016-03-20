var express = require('express');
var bodyParser = require('body-parser')
var request = require('request')
var session = require('express-session')
var router = express.Router();
var mysql = require('mysql')

var connection = mysql.createConnection({
  host    : 'se3450.cl7tq4md0ynb.us-west-1.rds.amazonaws.com',
  user    : 'Mach5',
  password: 'DarthVader',
  port    : '3306',
  database: 'se3450'
})

//a basic query of the mysql database
connection.query('SHOW TABLES', function(err, data) {
  if (err) throw err;
  console.log(data);
 });

router.get('/', function(req, res) {
  res.render('profLogin')
})


router.post('/', function(req, res) {
	var form = req.body
	//check is against the schools list of valid employee Anumbers
	//if they are good, route them to a webpage based on their classes.
	if(false){
		res.render('profLogin',{
			error_message: "Invalid A-number"
		})
	}else{
		return res.redirect(form.a_number);
	}

})
router.get('/data/:id', function(req,res){
	//return data only associated with the professor
	  // CSP headers
  res.set("Access-Control-Allow-Origin", "*");
  res.set("Access-Control-Allow-Headers", "X-Requested-With");
  //here i'll create a json object with dates and a count and serve it up
  //these need to be sorted on date before being passed
  var fakeData = {
  	"A01281942":
  	[
   		{
  			"date":"20160104",
  			"count":1
  		},
   		{
  			"date":"20160105",
  			"count":100
  		},
  		{
  			"date":"20160301",
  			"count":10
  		},
  		{
  			"date":"20160302",
  			"count":20
  		},
  		{
  			"date":"20160303",
  			"count":13
  		},
  		{
  			"date":"20160304",
  			"count":7
  		},

    	{
  			"date":"20160305",
  			"count":50
  		},
     	{
  			"date":"20160306",
  			"count":10
  		},
      {
        "date":"20160313",
        "count":10
      },
      {
        "date":"20160314",
        "count":12
      },
      {
        "date":"20160315",
        "count":2
      },
  	]
  }
	res.send(fakeData);
})

router.get('/:anum', function(req,res){
	res.render('datapage',{
		anum: JSON.stringify(req.params.anum)
	});
})

module.exports = router
