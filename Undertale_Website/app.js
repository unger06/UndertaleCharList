const apiUrl = 'http://localhost:6969/char/mainChar';

const getCharacterData = async () => {
  try {
    const response = await fetch(apiUrl);
    const data = await response.json();
    console.log(data);

    const characterInfoContainer = document.getElementById('character-info');
    characterInfoContainer.innerHTML = data.map((character) => {
      console.log(character);
      var text = 
      `<div class="character">
          <h1>${character.name}</h1>
          <p><strong>Appearances:</strong> ${character.appearances.join(', ')}</p>
          <p><strong>Role:</strong> ${character.role}</p>
          <p><strong>Status:</strong> ${character.status}</p>
          <p><strong>Max Health:</strong> ${character.maxHealth}</p>
          <h2>Abilities:</h2>
          <ul>`;
      
      for (let i in character.abilities) {
        text += `<li><strong>${character.abilities[i].name}:</strong> ${character.abilities[i].features.join(', ')}</li>`
      }


      text +=           
      `  </ul>
      </div>`
      return text;
      
    }).join('');

    
  } catch (error) {
    console.error(error);
  }
}

// getCharacterData();


const createCharacterCard = async () => {

  try {
    const response = await fetch(apiUrl);
    const data = await response.json();
    console.log(data);

    const characterInfoContainer = document.getElementById('character-card');
    characterInfoContainer.innerHTML = data.map((character) => {
      console.log(character);
      var text = 
        `<div class="card">
        <h2 class="card-title">${character.name}</h2>
        <div class="card-info">
          <p><strong>Appearances:</strong> <span class="appearances">${character.appearances.join(', ')}</span></p>
          <p><strong>Role:</strong> <span class="role">${character.role}</span></p>
          <p><strong>Status:</strong> <span class="status">${character.status}</span></p>
          <p><strong>Max Health:</strong> <span class="max-health">${character.maxHealth}</span></p>
          <h3>Abilities:</h3>
          <ul class="abilities">
            
        `;
      
    for (let i in character.abilities) {
      text += `<li><strong><span class="ability-${i+1}-name">${character.abilities[i].name}</span>:</strong> <span class="ability-${i+1}-features">${character.abilities[i].features.join(', ')}</span></li>`;
    }

    text +=           
          `</ul>
        </div>
      </div>`
    return text;
      
    }).join('');

    
  } catch (error) {
    console.error(error);
  }
}

createCharacterCard();