import { ServerApi, IMzrValidationResult, MzrInput, Gender } from "../../server-api/server-api";
import { inject } from 'aurelia-framework'

@inject(ServerApi)
export class PassportMzrValidator {
    title: string = "Validator";
    validationResult: IMzrValidationResult;
    serverApi: ServerApi;
    inputValue: MzrInput;

    constructor(serverApi: ServerApi) {
        this.serverApi = serverApi;
        this.validationResult = { message: "No Validation Attempted", valid: false };
        this.inputValue = {
            DateOfBirth: new Date(),
            DateOfExpiry: new Date(),
            Gender: Gender.Male,
            Mzr: "",
            Nationality: "",
            PassportNo: ""
        };
    }

    ValidateMzr(): void {
        console.log(this.inputValue);
        this.serverApi.ValidateMzr(this.inputValue)
            .then(result => this.validationResult = result);
    }
}