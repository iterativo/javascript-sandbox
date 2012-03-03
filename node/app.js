var utils = require('./utils');

var a = { one: 1 };
var b = { two: 2 };
utils.merge(a, b);
console.dir(a);
