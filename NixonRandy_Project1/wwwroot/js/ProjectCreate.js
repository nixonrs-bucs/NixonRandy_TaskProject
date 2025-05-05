'use strict';
import { ProjectRepo } from "./ProjectRepo.js";

const projectRepo1 = new ProjectRepo('https://localhost:7078/api/project');

const createProject = document.getElementById('createProject');
createProject.addEventListener("submit", async (e) => {
    e.preventDefault();
    try {
        const formData = new FormData(createProject);
        for (const [key, value] of formData.entries()) {
            console.log(key, value);
        }
        const result = await projectRepo1.create(formData);
        console.log(result);
        window.location.replace("/Dashboard/Index");
    } catch (e) {
        console.error(`Something went wrong: ${e}`);
    }
})