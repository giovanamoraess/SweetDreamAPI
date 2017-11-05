var mongoClient = require("mongodb").MongoClient;
mongoClient.connect("mongodb://localhost/test")
            .then(conn => global.conn = conn)
            .catch(err => console.log(err))

module.exports = { }

function findAll(callback){  
    global.conn.collection("customers").find({nome:'Nicholas'}).toArray(callback);
}

function findAllProdutos(callback){  
    global.conn.collection("produtos").find().toArray(callback);
}

function insert(customer, callback){
    global.conn.collection("customers").insert(customer, callback);
}

module.exports = { findAll, insert, findAllProdutos }

