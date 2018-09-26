export class LegacyLinks {
    public EditLink: string;
    public DetailsLink: string;
    public DeleteLink: string;

    constructor(id: number) {
        this.EditLink = `User/Edit/${id}`;
        this.DetailsLink = `User/Details/${id}`;
        this.DeleteLink = `User/Delete/${id}`;
    }
}
