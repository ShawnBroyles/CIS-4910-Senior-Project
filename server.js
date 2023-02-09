const express = require('express');
const app = express();
const PORT = 3000;

app.get('/', function(request, response) {
	response.send('Welcome to the main page. Check out the <a href="/welcome">welcome</a> page.');
});

app.get('/welcome', function(request, response) {
	response.sendFile(__dirname + '/public/welcome.html');
});

app.use(express.static('public')); 
app.use('/images', express.static('images'));

app.listen(PORT, ()=> console.log('\nEnsure that port 3000 is port-forwarded to allow connections over the internet.\nThe server will stay alive until this command prompt is closed.\n\nServer running on port 3000.\n'));