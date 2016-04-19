var express = require('express');
var bodyParser = require('body-parser')
var request = require('request')
var session = require('express-session')
var router = express.Router();
var mysql = require('mysql');
var moment = require('moment')
var _     = require('underscore')

var profList = ['ALLAN','WATSON','LEE','CHENG',
'CHRISTENSEN','CLYDE','DUHADWAY','DYRESON','FLANN',
'HANSEN','HOLDAWAY','HUGHES','JIANG','KULYUKIN',
'KWON','MANO','MASCO','MATHIAS','NGUYE','QI',
'SUNDBERG','WILLIS']

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

router.get('/:lname/:course',function(req,res){
  console.log(req.params);
  var querystring;
  querystring = 'select * from studentSessions where teacher like \'%'+req.params.lname+'\'';
  connection.query(querystring,function(err,data){
      if(err) throw err;
      alldata = data;
  }) 
  querystring = 'select classList.cName, teacherList.tName FROM classList INNER JOIN teacherList ON classList.tID = teacherList.tID WHERE teacherList.tName = \'Dan Watson\'';
  connection.query(querystring,function(err,data){
    if(err) throw err;
    classdata = data;
    console.log(classdata);
    console.log(alldata);
    res.render('datapage',{
      lname: JSON.stringify(req.params.lname),
      data:JSON.stringify(alldata),
      courses:JSON.stringify(classdata)
    });
  })

});
//for individual queries
// router.get('/data/:id/:date', function(req,res){
//   //these queries need to be professor specific
//   var date = req.params.date
//   var querystring;
//   if(date.length > 2){
//       //query for +- 3 days from this date.
//       date = date.replace(/_/g, '/')
//       var upperDate = moment(date).format('MM/DD/YYYY');
//       upperDate = moment(upperDate).add(3,'day');
//       var lowerDate = moment(date).format('MM/DD/YYYY');
//       lowerDate = moment(lowerDate).subtract(3,'day');
//       upperDate = upperDate.format('MM/DD/');
//       lowerDate = lowerDate.format('MM/DD/');
//       //remove preceding 0's to format similar to SQL timeIn string
//       if(upperDate.charAt(0) === '0'){
//         upperDate = upperDate.substr(1);
//       }
//       if(lowerDate.charAt(0) === '0'){
//         lowerDate = lowerDate.substr(1);
//       }
//       querystring = 'select * from studentSessions where timeIn between \''+lowerDate+'%\' and \''+upperDate+'%\''
//     }else{
//       //query for month data
//       date++;
//       querystring = 'select * from studentSessions where timeIn like \''+date+'/%\'';
//   }
//   connection.query(querystring,function(err,data){
//       //here we need to build the JSON object based on the queries to make it look like fakeData
//       if(err) throw err;
//       console.log(data)
//   })
//   // CSP headers
//   res.set("Access-Control-Allow-Origin", "*");
//   res.set("Access-Control-Allow-Headers", "X-Requested-With");
//   //here i'll create a json object with dates and a count and serve it up
//   //NOTE: these NEED to be sorted on date before sending.
//   var fakeData = {
//     "Watson":
//     [
//       {
//         "date":"20160104",
//         "count":1
//       },
//       {
//         "date":"20160105",
//         "count":100
//       },
//       {
//         "date":"20160301",
//         "count":10
//       },
//       {
//         "date":"20160302",
//         "count":20
//       },
//       {
//         "date":"20160303",
//         "count":13
//       },
//       {
//         "date":"20160304",
//         "count":7
//       },

//       {
//         "date":"20160305",
//         "count":50
//       },
//       {
//         "date":"20160306",
//         "count":10
//       },
//       {
//         "date":"20160313",
//         "count":10
//       },
//       {
//         "date":"20160314",
//         "count":12
//       },
//       {
//         "date":"20160315",
//         "count":2
//       },
//       {
//         "date":"20160322",
//         "count":2
//       },
//       {
//         "date":"20160323",
//         "count":15
//       },
//     ]
//   }
//   res.send(fakeData);
// })


router.get('/data/:lname', function(req,res){
  // CSP headers
  res.set("Access-Control-Allow-Origin", "*");
  res.set("Access-Control-Allow-Headers", "X-Requested-With");
  var dates = [];
  //console.log(req.params)
  var querystring;
  querystring = 'select * from studentSessions where teacher like \'%'+req.params.lname+'\'';
  //console.log(querystring)
  connection.query(querystring,function(err,data){
      //here we need to build the JSON object based on the queries to make it look like fakeData
      if(err) throw err;
      console.log(data)
      //iterate the objects, if there is a date and its not in the map of dates, push it to the map of dates,
      //if it is, increment its count
      //console.log(data)
      //sadly this code is going to need to go in the frontend
      // console.log('SENDING');
      // console.log(dates)
      res.send(data);
  })  
  //here query for all data associated with the professor
  //turn it into a JSON object like 'fakeData'
  //here i'll create a json object with dates and a count and serve it up
  //NOTE: these NEED to be sorted on date before sending.
  // var fakeData = {
  // 	"Watson":
  // 	[
  //  		{
  // 			"date":"20160104",
  // 			"count":1
  // 		},
  //  		{
  // 			"date":"20160105",
  // 			"count":100
  // 		},
  // 		{
  // 			"date":"20160301",
  // 			"count":10
  // 		},
  // 		{
  // 			"date":"20160302",
  // 			"count":20
  // 		},
  // 		{
  // 			"date":"20160303",
  // 			"count":13
  // 		},
  // 		{
  // 			"date":"20160304",
  // 			"count":7
  // 		},

  //   	{
  // 			"date":"20160305",
  // 			"count":50
  // 		},
  //    	{
  // 			"date":"20160306",
  // 			"count":10
  // 		},
  //     {
  //       "date":"20160313",
  //       "count":10
  //     },
  //     {
  //       "date":"20160314",
  //       "count":12
  //     },
  //     {
  //       "date":"20160315",
  //       "count":2
  //     },
  //     {
  //       "date":"20160322",
  //       "count":2
  //     },
  //     {
  //       "date":"20160323",
  //       "count":15
  //     },
  // 	]
  // }
	// res.send(fakeData);
})

router.get('/:lname', function(req,res){
  var alldata;
  var classdata;
  var querystring;
  querystring = 'select * from studentSessions where teacher like \'%'+req.params.lname+'\'';
  // querystring = 'select classList.cName, teacherList.tName FROM classList INNER JOIN teachList on classList.tID = teachList.tID'
  //console.log(querystring)
  connection.query(querystring,function(err,data){
      //here we need to build the JSON object based on the queries to make it look like fakeData
      if(err) throw err;
      alldata = data;
      // console.log(data)
      // res.render('datapage',{
      //   lname: JSON.stringify(req.params.lname),
      //   data:JSON.stringify(data)
      // });
  }) 
  querystring = 'select classList.cName, teacherList.tName FROM classList INNER JOIN teacherList ON classList.tID = teacherList.tID WHERE teacherList.tName = \'Dan Watson\'';
  connection.query(querystring,function(err,data){
    if(err) throw err;
    classdata = data;
    console.log(classdata);
    console.log(alldata);
    res.render('datapage',{
      lname: JSON.stringify(req.params.lname),
      data:JSON.stringify(alldata),
      courses:JSON.stringify(classdata)
    });
  })

})

module.exports = router
