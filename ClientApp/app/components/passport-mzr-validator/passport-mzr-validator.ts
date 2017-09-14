import { ServerApi, IMzrValidationResult, MzrInput, Gender } from "../../server-api/server-api";
import { inject } from "aurelia-framework";

@inject(ServerApi)
export class PassportMzrValidator {
    title: string = "Validator";
    validationResults: IMzrValidationResult[];
    serverApi: ServerApi;
    inputValue: MzrInput;

    constructor(serverApi: ServerApi) {
        this.serverApi = serverApi;
        this.validationResults = [ { field: "error", status: "Error", message: "Not validated yet" } ];
        this.inputValue = {
            DateOfBirth: new Date(),
            DateOfExpiry: new Date(),
            Gender: Gender.Male,
            Mzr: "",
            Nationality: "",
            PassportNo: ""
        };
        let isValid: boolean = this.validationResults.some((v, i, a) => { return v.field === "Mzr" && v.status === "Error"; });
    }

    ClassValidator(field: string, status: string): string {
        return this.validationResults.some((v) => v.field === field && v.status === status) ? "has-error" : "";
    }

    ValidateMzr(): void {
        console.log(this.inputValue);
        this.serverApi.ValidateMzr(this.inputValue)
            .then(result => {
                this.validationResults = result;
            })
    }
}