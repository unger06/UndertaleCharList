const apiUrl = 'http://localhost:6969/char/mainChar';

const getMainCharacters = async () => {
  try {
    const response = await fetch(apiUrl);
    const data = await response.json();

    const charactersContainer = document.getElementById('character-card');
    let charactersHTML = '';

    data.forEach(character => {
        console.log(character.name);
        const card = createCharacterCard(character);
        charactersHTML += card;
    });
    charactersContainer.innerHTML = charactersHTML;
  } catch (error) {
    console.error(error);
  }
};

const createCharacterCard = (character) => {

    console.log(character);
    var text = 
        `<div class="card">
            <h2 class="card-title">${character.name}</h2>
            <div class="card-info">
                <p><u>Appearances:</u> <span class="appearances"><br>${character.appearances.join(', ')}</span></p>
                <p><u>Role:</u> <span class="role"><br>${character.role}</span></p>
                <p><u>Status:</u> <span class="status"><br>${character.status}</span></p>
                <p><u>Max Health:</u> <span class="max-health"><br>${character.maxHealth}</span></p>
                <h3>Abilities:</h3>
                <ul class="abilities">          
    `;
        
    for (let i in character.abilities) {
        text += `<li><u><span class="ability-${i+1}-name">${character.abilities[i].name}</span>:</u> <span class="ability-${i+1}-features"><br>${character.abilities[i].features.join(', ')}</span></li>`;
    }

    text +=           
            `</ul>
        </div>
    </div>`
    return text;       
}

getMainCharacters();