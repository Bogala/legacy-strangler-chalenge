export class LegacyLinks {
    public EditLink: string;
    public DetailsLink: string;
    public DeleteLink: string;

    constructor(baseUrl: string, id: number) {
        this.EditLink = `${baseUrl}User/Edit/${id}`;
        this.DetailsLink = `${baseUrl}User/Details/${id}`;
        this.DeleteLink = `${baseUrl}User/Delete/${id}`;
    }
}