module.exports = async function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    const inputs = ((req.body && req.body.repository.full_name));
    const gitHubNotification = req.body;

    if (inputs) {
        // Writing in Table Storage
        context.bindings.tableBinding = [];

        const uniqueId = context.bindingData.after; // uuidv4();
        const dataToBeStored = {
            PartitionKey: gitHubNotification.repository.owner.name,
            RowKey: uniqueId,
            FullName: gitHubNotification.repository.full_name,
            OwnerName: gitHubNotification.repository.owner.name,
            RepoUrl: gitHubNotification.repository.html_url,
            AuthorName: gitHubNotification.commits[0].author.name,
            Added: gitHubNotification.commits[0].added,
            Removed: gitHubNotification.commits[0].removed,
            Modified: gitHubNotification.commits[0].modified,
            blobName: uniqueId
        };

        // Writing to Blob
        context.bindings.textfiles = dataToBeStored;

        // Writing to Table
        context.bindings.tableBinding.push(dataToBeStored);
    }

    context.res = (inputs) ? {
        status: 200,
        body: {
            success: true,
            fullName: gitHubNotification.repository.full_name,
            executedAt: process.env["COMPUTERNAME"],
            message: 'Changes has be captured in Table Storage'
        }
    } : {
        status: 400,
        body: {
            success: false,
            executedAt: process.env["COMPUTERNAME"],
            message: "We did not received the proper notification from GitHub."
        }
    };
}

function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

