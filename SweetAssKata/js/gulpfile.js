var gulp = require('gulp');
var karma = require('karma');

gulp.task('default', function (done) {
    var karmaServer = new karma.Server({
        configFile: __dirname + '/karma.conf.js'
    }, function () {
        done();
    }).start();
});