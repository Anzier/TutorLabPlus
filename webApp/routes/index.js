var express = require('express');
var bodyParser = require('body-parser')
var request = require('request')
var session = require('express-session')
var router = express.Router();
var Connection = require('tedious').Connection
var config   = {
	userName : 'Mach5',
	password : '#DarthVader',
	server   : 'se3450.database.windows.net',
	options  : {encrypt:true,database:'AdventureWorks'}
}

var connection = new Connection(config);
connection.on('connect',function(err){
	console.log(err)
	if(!err){
		console.log('connected')
	}
})

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
router.get('/data', function(req,res){
	  // CSP headers
  res.set("Access-Control-Allow-Origin", "*");
  res.set("Access-Control-Allow-Headers", "X-Requested-With");
	res.send([{x:500,y:125,r:10},
			  {x:250,y:125,r:10},
			  {x:200,y:250,r:10}]);
})

router.get('/:anum', function(req,res){
	res.render('datapage',{
		anum: req.params.anum
	});
})

module.exports = router
