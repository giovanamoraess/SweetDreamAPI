var express = require('express');
var router = express.Router();


/* GET home page. */
router.get('/', function(req, res) {
  global.db.findAll((e, docs) => {
      if(e) { return console.log(e); }
      res.status(200).send({
       	docs
      });
  })
})

router.get('/produtos', function(req, res) {
  global.db.findAllProdutos((e, docs) => {
      if(e) { return console.log(e); }
      res.status(200).send({
       	docs
      });
  })
})

router.get('/new', function(req, res, next) {
  res.render('new', { title: 'Novo Cadastro' });
});

router.post('/new', function(req, res) {
  var nome = req.body.nome;
  var idade = parseInt(req.body.idade);
  global.db.insert({nome, idade}, (err, result) => {
          if(err) { return console.log(err); }
          res.redirect('/');
      })
})

module.exports = router;
