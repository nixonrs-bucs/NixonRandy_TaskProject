'use strict';
import { ProjectRepo } from './ProjectRepo.js';
//import { DOM } from "./DOMCreator.js";

const projectRepo1 = new ProjectRepo('https://localhost:7078/api/project');
let projectReadAll = await projectRepo1.readAll();
console.log(projectReadAll);
function addProjectToTable(tbody, project) {
    const tr = document.createElement('tr');
    tbody.appendChild(tr);

    let td = document.createElement('td');
    td.textContent = project.ProjectId;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = project.Title;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = project.Description;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = project.CreationDate;
    tr.appendChild(td);

    td = document.createElement('td');
    td.textContent = project.DueDate;
    tr.appendChild(td);

    /*td = document.createElement('a');
    let link = createLink('Edit', `/Dashboard/edit/${project.ProjectId}`, 'warning');
    td.append(link);
    tr.appendChild(td);

    td = document.createElement('a');
    link = createLink('Details', `/Dashboard/details/${project.ProjectId}`, 'info');
    td.append(link);
    tr.appendChild(td);

    td = document.createElement('a');
    link = createLink('Delete', `/Dashboard/delete/${project.ProjectId}`, 'danger');
    td.append(link);*/
    tr.appendChild(td);
    tbody.appendChild(tr);
}


const tablebody = document.getElementById('tablebody');

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

async function populateProjects(projectRepo) {
    const tbody = document.getElementById('tablebody');
    try {
        const Projects = await projectRepo.readAll();
        Projects.forEach(projects => {
            addProjectToTable(tbody, projects); 
        });
        return Projects;
    } catch (error) {
        console.error("Error populating board games:", error);
    }
}
console.log(await populateProjects(projectRepo1));

function createLink(text, url, btntype) {
    const a = document.createElement('a');
    a.setAttribute("href", `${url}`);
    a.setAttribute("class", `btn btn-${btntype} mx-1`);
    a.setAttribute("text", `${text}`);
    a.textContent = text;
    return a;
}

