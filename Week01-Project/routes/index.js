var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res, next) { 'use strict';
  res.render('index', { title: 'Week01-Project' });
});
router.get('/orders', function(req, res, next) { 'use strict';
  res.render('orders', { title: 'Week01-Project' });
});
/* GET orders page. */

router.post('/addOrder', function(request, response) {

  // Set our internal DB variable
  var db = request.db;

  // Get our form values. These rely on the "name" attributes
  var itemNumber = request.query.itemNumber;
  var timePurch = request.query.timePurch;
  var storeNumber = request.body.storeNumber;
  var pricePaid = request.body.pricePaid;
  var salesPersonID = request.body.salesPersonID;

  // Set our collection
  var collection = db.get('ordercollection');
  collection.find({},{},function(e,docs){
    res.render('myList', {
      "myList" : docs
    });
  });

  var order = {
    "itemNumber" : itemNumber,
    "timePurch" : timePurch,
    "storeNumber":storeNumber,
    "pricePaid":pricePaid,
    "salesPersonID":salesPersonID
  };

  // Submit to the DB
  collection.insert(order, function (err, doc) {
    if (err) {
      // If it failed, return error
      response.send("There was a problem adding the information to the database.");
    }
    else {
      // And forward to success page
      response.redirect("ordercollection");
    }
  });
});

module.exports = router;
