'use strict';
import { ProjectRepo } from './ProjectRepo.js';
//import { DOM } from "./DOMCreator.js";

const projectRepo1 = new ProjectRepo('https://localhost:7099/api/boardgame');
let boardGames = await boardGameRepository.readAll();
console.log(boardGames);
function addBoardGameToTable(tbody, boardGame) {
    const tr = document.createElement('tr');
    tbody.appendChild(tr);

    let td = document.createElement('td');
    td.textContent = boardGame.id;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = boardGame.title;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = boardGame.maxPlayers;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = boardGame.minPlayers;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = boardGame.playingTimeMinutes;
    tr.appendChild(td);

    td = document.createElement('a');
    let link = createLink('Edit', `/boardgame/edit/${boardGame.id}`, 'warning');
    td.append(link);
    tr.appendChild(td);

    td = document.createElement('a');
    link = createLink('Details', `/boardgame/details/${boardGame.id}`, 'info');
    td.append(link);
    tr.appendChild(td);

    td = document.createElement('a');
    link = createLink('Delete', `/boardgame/delete/${boardGame.id}`, 'danger');
    td.append(link);
    tr.appendChild(td);
}

const tbodyBoardGameTable = document.getElementById('tbodyBoardGameTable');

/*const firstBoardGame = {
    id: 1,
    title: "Ticket to Ride",
    maxPlayers: 5,
    minPlayers: 2,
    playingTimeMinutes: 60
};*/

/*if (tbodyBoardGameTable && firstBoardGame) {
    addBoardGameToTable(tbodyBoardGameTable, firstBoardGame);
}*/

async function populateBoardGames(boardGameRepo) {
    const tbody = document.getElementById('tbodyBoardGameTable');
    try {
        const boardGames = await boardGameRepo.readAll();
        boardGames.forEach(boardGame => {
            addBoardGameToTable(tbody, boardGame);
        });
        return boardGames;

    } catch (error) {
        console.error("Error populating board games:", error);
    }
}
console.log(await populateBoardGames(boardGameRepository));

function createLink(text, url, btntype) {
    const a = document.createElement('a');
    a.setAttribute("href", `${url}`);
    a.setAttribute("class", `btn btn-${btntype} mx-1`);
    a.setAttribute("text", `${text}`);
    a.textContent = text;
    return a;
}

