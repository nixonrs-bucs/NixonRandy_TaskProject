'use strict';
import { BoardGameRepository } from "./BoardGameRepository.js";

const boardGameRepo = new BoardGameRepository('https://localhost:7099/api/boardgame');

const createBoardGame = document.getElementById('formCreateBoardGame');
createBoardGame.addEventListener("submit", async (e) => {
    e.preventDefault();
    try {
        const formData = new FormData(createBoardGame);
        for (const [key, value] of formData.entries()) {
            console.log(key, value);
        }
        const result = await boardGameRepo.create(formData);
        console.log(result);
        window.location.replace("/Dashboard/Index");
    } catch (e) {
        console.error(`Something went wrong: ${e}`);
    }
})