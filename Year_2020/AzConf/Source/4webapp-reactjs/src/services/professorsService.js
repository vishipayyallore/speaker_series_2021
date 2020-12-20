// const baseUrl = 'https://localhost:5002/api/v1/professors';
const baseUrl = 'https://api.azurewebsites.net/api/v1/professors';

export async function getAllProfessors() {

    return fetch(baseUrl)
        .then(handleResponse)
        .catch(handleError);
}

export async function getProfessorById(ProfessorId) {

    return fetch(`${baseUrl}/${ProfessorId}`)
        .then(handleResponse)
        .catch(handleError);
}

export async function saveProfessor(professorDto) {

    return fetch(baseUrl, {
        method: "POST",
        headers: { "content-type": "application/json" },
        body: JSON.stringify({
            ...professorDto
        })
    })
        .then(handleResponse)
        .catch(handleError);
}

export async function editProfessor(professorDto) {

    return fetch(`${baseUrl}`, {
        method: "PUT",
        headers: { "content-type": "application/json" },
        body: JSON.stringify({
            ...professorDto
        })
    })
        .then(handleResponse)
        .catch(handleError);
}

export async function deleteProfessorById(professorId) {

    return fetch(`${baseUrl}/${professorId}`, { method: "DELETE" })
        .then(handleResponse)
        .catch(handleError);
}

async function handleResponse(response) {

    if (response.ok) {
        if (response.status === 204) {
            return;
        }
        else {
            return response.json();
        }
    }

    if (response.status !== 200 || response.status !== 201) {
        const error = await response.text();
        throw new Error(error);
    }

    throw new Error("Network response was not ok.");
}

function handleError(error) {
    console.error("API call failed. " + error);
    throw error;
}
