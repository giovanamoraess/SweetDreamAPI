var mongoClient = require("mongodb").MongoClient;
mongoClient.connect("mongodb://localhost/workshoptdc")
            .then(conn => global.conn = conn)
            .catch(err => console.log(err))

module.exports = { }

function findAll(callback){  
    global.conn.collection("customers").find({}).toArray(callback);
}

module.exports = { findAll }

