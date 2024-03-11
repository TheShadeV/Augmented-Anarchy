const questions = [
    {
        'id' : '1',
        'q' : 'What type of games do you prefer the most?',
        'res' : ['a. Action-adventure', 'b. Role-playing (RPG)', 'c. Strategy', 'd. Open world'],
        'val' : ['6','5','4','3'],
    },

    {
        'id' : '2',
        'q' : 'How important is graphics to you in a game?',
        'res' : ['a. Very important, I only play games with the latest and best graphics.', 'b. Not so important, I care more about gameplay and story.', 'c. I don\'t care about it, I also enjoy the graphics of older games.'],
        'val' : ['3','5','7'],
    },

    {
        'id' : '3',
        'q' : 'What difficulty level do you like to play?',
        'res' : ['a. High, where the challenge is always present.', 'b. Medium, where there is challenge but not too frustrating.', 'c. Low, I prefer the experience and entertainment.'],
        'val' : ['6','4','2'],
    },

    {
        'id' : '4',
        'q' : 'Do you prefer single-player or multiplayer modes?',
        'res' : ['a. I mostly play single-player games.', 'b. I like both, depending on my mood.', 'c. I mainly participate in multiplayer games.'],
        'val' : ['5','4','3'],
    },

    {
        'id' : '5',
        'q' : 'How often do you play video games?',
        'res' : ['a. Every day, for several hours.', 'b. Several times a week.', 'c. Rarely, only occasionally when I have time.'],
        'val' : ['7','4','2'],
    },

    {
        'id' : '6',
        'q' : 'How important is the game story to you?',
        'res' : ['a. Very important, I like to play games with deep, complex stories.', 'b. Not so important, but I still appreciate a good background story.', 'c. It is not essential to me, gameplay is more important.'],
        'val' : ['5','3','1'],
    },

    {
        'id' : '7',
        'q' : 'On which platform do you play most often?',
        'res' : ['a. PC', 'b. Console (e.g., PlayStation, Xbox)', 'c. Mobile'],
        'val' : ['6','5','3'],
    },

    {
        'id' : '8',
        'q' : 'In which gameplay style do you feel most comfortable?',
        'res' : ['a. Fast action', 'b. Slower-paced strategy', 'c. Calm exploration and discovery'],
        'val' : ['5','4','3'],
    },

    {
        'id' : '9',
        'q' : 'Do you prefer realistic or fantasy worlds?',
        'res' : ['a. Realistic worlds', 'b. Fantasy worlds', 'c. I like both equally.'],
        'val' : ['4','6','5'],
    },

    {
        'id' : '10',
        'q' : 'Which game element is most important to you in a game?',
        'res' : ['a. Gameplay', 'b. Graphics', 'c. Story', 'd. Multiplayer mode'],
        'val' : ['5','3','7','4'],
    },
];

function docLoad(file) {
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function() {
        document.getElementById("content").innerHTML = this.responseText;
    }
    xhttp.open("GET", "../templates/" + file + ".html", true);
    xhttp.send();
}

function questionLoad() {
    let text = '';
    let szamlalo = 1;
    text += '<h2 style="text-align:center;">Questions</h2>';
    for (let x in questions) {
        text += '<div class="mb-3">';
        text += '<p><b>' + szamlalo + '. ' + questions[x]['q'] + '</b></p>';
        szamlalo++;

        for (let i = 0; i < questions[x]['res'].length; i++) {
            text += '<input class="form-check-input" type="radio" id="q' + questions[x]['id'] + '" name="q' + questions[x]['id'] + '" value="' + questions[x]['val'][i] + '">';
            text += '<label class="form-check-label ms-2" for="q' + questions[x]['id'] + '">' + questions[x]['res'][i] + '</label><br>';
        }

        text += '</div>';
    }
    text += '<button type="submit" onclick="formValidate()" class="btn btn-success btn-lg mt-5 mb-5">Evaluate Results</button>';
    document.getElementById('questions').innerHTML = text;
}

function formValidate() {
    let pontok = 0;
    const questionForm = document.getElementById('questionForm');

    questionForm.addEventListener('submit', (event) =>
        event.preventDefault());

    const selectedOptions = [];
    for (let i = 1; i <= 10; i++) {
        const selectedOption = document.querySelector('input[name="q' + i + '"]:checked');
        if (selectedOption) {
            selectedOptions.push(parseInt(selectedOption.value));
        }
    }

    pontok = selectedOptions.reduce((total, value) => total + value, 0);

    const resultElement = document.getElementById('pontok');
    const resultText = pontok === 1 ? 'point' : 'points';
    resultElement.innerHTML = '<h2 class="mt-3">Your Result:</h2>' + pontok + '&nbsp;' + resultText;

    const { message, imageSrc } = generateResultMessage(pontok);

    document.getElementById('eredmeny').innerHTML = '<p>' + message + '</p>';
    document.getElementById('kep').innerHTML = '<img class="pb-5" src="' + imageSrc + '">';
}

function generateResultMessage(pontok) {
    let message = '';
    let imageSrc = '';

    if (pontok < 7) {
        message = 'Your gaming habits are severely impacting your overall enjoyment and success in the rogue-like genre. It is highly recommended that you seek guidance or professional advice to address any underlying issues that may be contributing to your low score. A score this low may indicate that you are struggling with fundamental aspects of rogue-like gameplay, which can lead to frustration and decreased enjoyment. It is important for you to prioritize learning and practicing the key mechanics and strategies of rogue-like games to improve your gaming experience as soon as possible.';
        imageSrc = '';
    } else if (pontok >= 7 && pontok <= 14) {
        message = 'Your gaming habits in the rogue-like genre could use some improvement. It is recommended that you focus on developing a deeper understanding of game mechanics, such as character progression, item management, and strategic decision-making, to enhance your performance and enjoyment.';
        imageSrc = '';
    } else if (pontok >= 15 && pontok <= 21) {
        message = 'Your gaming habits in the rogue-like genre are average, but there is room for improvement. Consider honing your skills and experimenting with different playstyles to increase your success and satisfaction in rogue-like games.';
        imageSrc = '';
    } else if (pontok >= 22 && pontok <= 28) {
        message = 'Your gaming habits in the rogue-like genre are generally good, but there may still be areas to refine. Explore advanced tactics, optimize your character builds, and challenge yourself with harder difficulties to further enhance your gaming experience.';
        imageSrc = '';
    } else {
        message = 'Congratulations! You have excellent gaming habits in the rogue-like genre and are likely experiencing the thrill of mastering challenging gameplay and uncovering hidden secrets. Keep up the adventurous spirit and continue exploring the depths of rogue-like worlds!';
        imageSrc = '';
    }

    return { message, imageSrc };
}

const questionForm = document.getElementById('questionForm');
questionForm.addEventListener('submit', formValidate);