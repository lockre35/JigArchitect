var gulp = require('gulp');
var gutil = require('gulp-util'),
    concat = require('gulp-concat'),
    clean = require('gulp-clean');

// Browserify task
gulp.task('scripts', ['clean-scripts'], function() {
  // Any other view files from app/views
  gulp.src('./app/**/*.js')
  // Will be put in the dist/views folder
  .pipe(gulp.dest('wwwroot/app/'));
});

// Clean scripts
gulp.task('clean-scripts', function() {
  return gulp.src('wwwroot/app/**/*.js', {read: false})
  .pipe(clean());
});

// Views task
gulp.task('views', ['clean-views'], function() {
  // Get our index.html
  gulp.src('./index.html')
  // And put it in the dist folder
  .pipe(gulp.dest('wwwroot/'));

  // Any other view files from app/views
  gulp.src('./app/**/*.html')
  // Will be put in the dist/views folder
  .pipe(gulp.dest('wwwroot/app/'));
});

// Clean views
gulp.task('clean-views', ['clean-index'], function() {
  return gulp.src('wwwroot/app/**/*.html', {read: false})
  .pipe(clean());
});

// Clean index
gulp.task('clean-index', function(){
  return gulp.src('wwwroot/index.html', {read: false})
  .pipe(clean());
});

// Styles task
gulp.task('styles', ['clean-styles'], function() {
  gulp.src('./content/*.css')
  .pipe(gulp.dest('wwwroot/content/'));
});

// Clean styles
gulp.task('clean-styles', function() {
  return gulp.src('wwwroot/content/*.css', {read: false})
  .pipe(clean());
});

// Content task
gulp.task('content', ['clean-content'], function() {
  gulp.src('./content/images/*.*')
  .pipe(gulp.dest('wwwroot/content/images'));
});

// Clean styles
gulp.task('clean-content', function() {
  return gulp.src('wwwroot/content/images/*.*', {read: false})
  .pipe(clean());
});


// Clean wwwroot
gulp.task('clean', function() {
  gulp.src('./wwwroot/**', {read: false})
  .pipe(clean());
});

// Config task
gulp.task('config', ['clean-config'], function(){
  gulp.src('./web.config')
  .pipe(gulp.dest('wwwroot/'));
});

// Clean config
gulp.task('clean-config', function() {
  return gulp.src('wwwroot/web.config', {read: false})
  .pipe(clean());
});

gulp.task('rebuild', ['content', 'scripts', 'views', 'styles', 'config'], function(){
});

gulp.task('watch', function() {
  // Watch our scripts
  gulp.watch(['app/*.js', 'app/**/*.js'],[
    'scripts'
  ]);

  // Watch our views
  gulp.watch(['index.html', 'app/**/*.html'], [
  'views'
  ]);

  // Watch our styles
  gulp.watch(['./content/*.css'], [
  'styles'
  ]);

  // Watch our content
  gulp.watch(['./content/images/*.*'], [
  'content'
  ]);
});
