"use strict";
class ProjectRepo {
    #baseAddress;
    constructor(baseAddress) {
        this.#baseAddress = baseAddress;
    }

    async readAll() {
        try {
            const response = await fetch(`${this.#baseAddress}/all`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            return data;
        } catch (e) {
            console.error(`${e}`);
            window.location.replace("/Dashboard/Index");
        }
    }

    async read(id) {
        try {
            const address = `${this.#baseAddress}/one/${id}`;
            const response = await fetch(address);
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return await response.json();
        } catch (e) {
            console.error(`${e}`);
            window.location.replace("/Dashboard/Index");
        }
    }
    async create(formData) {
        try {
            const address = `${this.#baseAddress}/create`;
            const response = await fetch(address, {
                method: "post",
                body: formData
            });
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            console.log(await response.json());
        } catch (e) {
            console.error(`${e}`);
            window.location.replace("/Dashboard/Index");
        }
        //return await response.json();
    }

    async put(formData) {
        try {
            const address = `${this.#baseAddress}/update`;
            const response = await fetch(address, {
                method: "put",
                body: formData
            });
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return await response.text();
        } catch (e) {
            console.error(`${e}`);
            window.location.replace("/Dashboard/Index");
        }
    }

    async delete(id) {
        try {
            const address = `${this.#baseAddress}/delete/${id}`;
            const response = await fetch(address, {
                method: "delete"
            });
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return await response.text();
        } catch (e) {
            console.error(`${e}`);
        }
    }
}

export { ProjectRepo };
