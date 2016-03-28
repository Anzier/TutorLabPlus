var express = require('express');
var bodyParser = require('body-parser')
var request = require('request')
var session = require('express-session')
var router = express.Router();
var mysql = require('mysql')

var profList = ['Allan','Watson','Lee','Cheng',
'Christensen','Clyde','DuHadway','Dyreson','Flann',
'Hansen','Holdaway','Hughes','Jiang','Kulyukin',
'Kwon','Mano','Masco','Mathias','Nguyen','Qi',
'Sundberg','Willis']

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
	//check this against a valid list of professors last names
	if(profList.indexOf(form.lName) === -1){
		res.render('profLogin',{
			error_message: "Invalid Login"
		})
	}else{
		return res.redirect(form.lName);
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
  	"Watson":
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
      {
        "date":"20160322",
        "count":2
      },
      {
        "date":"20160323",
        "count":15
      },
  	]
  }
	res.send(fakeData);
})

router.get('/:lname', function(req,res){
  //lets render something else here, get a fresh start to the page design
	res.render('datapage',{
		lname: JSON.stringify(req.params.lname)
	});
})

module.exports = router
