var path = require('path');
var webpack = require('webpack');

module.exports = {
    entry: {
        homepage: './Scripts/Home/index.js',
        settingspage: './Scripts/Settings/index.js'
    },
    output: {
        publicPath: "/js/",
        path: path.join(__dirname, '/wwwroot/js/'),
        filename: '[name].build.js'
    },
    devtool: 'inline-source-map',
    module: {
        loaders: [{
            test: /.jsx?$/,
            loader: 'babel-loader',
            exclude: /node_modules/,
            query: {
                presets: ['es2015', 'react']
            }
        }]
    }
};