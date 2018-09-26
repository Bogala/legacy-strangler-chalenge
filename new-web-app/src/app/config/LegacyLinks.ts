export class LegacyLinks {
    public editLink: string;
    public detailsLink: string;
    public deleteLink: string;

    constructor(id: number) {
        this.editLink = `User/Edit/${id}`;
        this.detailsLink = `User/Details/${id}`;
        this.deleteLink = `User/Delete/${id}`;
    }
}
