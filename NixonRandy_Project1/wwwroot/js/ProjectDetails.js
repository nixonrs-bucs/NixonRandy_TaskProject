'use strict';
import { ProjectRepo } from "./ProjectRepo.js";
//https://localhost:7078/api/project/details/1
const projectRepo1 = new ProjectRepo('https://localhost:7078/api/project');

function getProjectIdFromUrl() {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get('id');
}

const projectId = getProjectIdFromUrl();
console.log(projectID);
const projectDetails = document.getElementById('projectDetails');
projectDetails.addEventListener("submit", async (e) => {
    e.preventDefault(e);
    try {
        const project = await projectRepo1.read(projectID);
        console.log(project);

        DOM.setElementText("#projectID", project.ProjectId);
        DOM.setElementText("#ProjectTitle", project.Title);
        DOM.setElementText("#ProjectDescription", project.Description);
        DOM.setElementText("#ProjectCreationDate", project.CreationDate);
        DOM.setElementText("#ProjectDueDate", project.DueDate);
    } catch (e) {
        console.error(`Error message: ${e}`);
        window.location.replace("/Dashboard/index");
    }
})