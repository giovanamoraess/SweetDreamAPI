var express = require('express');
var router = express.Router();

router.get('/', function(req, res) {
    global.db.findAllProdutos((e, docs) => {
        if(e) { return console.log(e); }
        res.status(200).send({
             docs
        });
    })
  })

module.exports = router;