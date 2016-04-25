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

var teacherName;

connection.query('select * from teacherList where tID = 1', function(err, data) {
  if (err) throw err;
  teacherName = data;

  console.log(teacherName);
  console.log("there should be a gap with the same stuff above and below");
  console.log(data);
  //so i was able to store the variable of teacher name within this connection query 
  //but could not have it in later uses elsewhere... hmmm.
 });


console.log('here is the teacherName' , teacherName);

connection.query('SELECT * FROM classList WHERE tID1 = 1' ,function(err, data){
	if(err) throw err;
	console.log(data);
});

connection.query("select classList.cName, teacherList.tName FROM classList INNER JOIN teacherList ON classList.tID1 = teacherList.tID WHERE teacherList.tName = 'Dan Watson'" ,function(err, data){
	if(err) throw err;
	console.log(data);
});

connection.query("SELECT * FROM studentSessions where teacher = 'Dan Watson'" ,function(err, data){
	if(err) throw err;
	console.log(data);
});

//so if you look at the following links from the original
//the below router.gets will have all of our data displayed under that given link
//so what i am wondering is why cant we do the same with the main
// go down three functions **** <=====
router.get('/data', function(req, res){
  connection.query('SELECT * FROM classList', function(err, rows, fields){
    res.render('data', {
      items: rows
    });
  });
});

router.get('/studentData', function(req, res){
  connection.query('SELECT * FROM studentSessions', function(err, rows, fields){
    res.render('studentData', {
      items: rows
    });
  });
});

router.get('/teacherList', function(req, res){
  connection.query('SELECT * FROM teacherList', function(err, rows, fields){
    res.render('teacherList', {
      items: rows
    });
  });
});

router.get('/joinedTeacherClass', function(req, res){
  connection.query("select classList.cName, teacherList.tName FROM classList INNER JOIN teacherList ON classList.tID1 = teacherList.tID " , function(err, rows, fields){
    res.render('joinedTeacherClass', {
      items: rows
    });
  });
});

router.get('/specificData/:tName', function(req, res){
  var checker = req.params.tName;
  console.log(checker)
  console.log("tried to go to specificData");
    connection.query('SELECT * FROM studentSessions where teacher = ?', [checker], function(err, rows, fields){
  res.render('specificData', {
    items:rows
  });
});
});

router.get('/', function(req, res) {
  res.render('adminLog')
})

router.post('/', function(req, res) {
  var form = req.body
  //check this against a valid list of professors last names
  if(form.password !== "kyloRen"){
    res.render('adminLog',{
      error_message: "Invalid Login"
    })
  }else{
    //res.render('main');
    //return res.redirect(form.password);
    res.redirect('main');
  }
})

router.get('/:password', function(req,res){
  //lets render something else here, get a fresh start to the page design
  connection.query('SELECT * FROM teacherList', function(err, rows, fields){
  res.render('main', {
    items:rows
    //items:JSON.stringify(rows)
  });
});
});



//*** <=====
//why not here. why cant we just call a query with all of the data 
//in student session
//databases are fast so maybe one call will be just fine
//then from there what if we used the item things i used
//inside of data.jade and studentData.jade to access the data we need
//seems like this should work.... and then just display our main page 
// (for each professor) with the appropriate data possible in a similar 
// fasion.
//  seems like it should work, but im no node.js expert here.


// router.get('/', function(req, res) {
//   res.render('main')
// })



// ^ so above here is where we need to start getting serious
//
//another thing to note with this model.
// with links we could have teachers access certain views and analytics by clicks 
// and then sending them to different views and pages

module.exports = router