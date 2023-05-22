const apiUrl = 'http://localhost:6969/char/vendor';

const getVendors = async () => {
  try {
    const response = await fetch(apiUrl);
    const data = await response.json();

    const charactersContainer = document.getElementById('character-card');
    let charactersHTML = '';

    data.forEach(character => {
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
                <h3>Wares:</h3>
                <ul class="wares">          
    `;
    
    Object.keys(character.features).forEach(wareKey => {
        const ware = character.features[wareKey];
        text += `<li><u>${ware.name}</u><br>Type: ${ware.type}<br>Price: ${ware.price.join(' / ')}<br>Heal: ${ware.heal}<br>Sell: ${ware.sell}</li>`;
      });

    text +=           
            `</ul>
        </div>
    </div>`
    return text;       
}

getVendors();