import { HttpClient, json } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";

@inject(HttpClient)
export class ServerApi {
    fetch: HttpClient;

    constructor(httpClient: HttpClient) {
        this.fetch = httpClient;
    }

    buildMzrObject(passportNo: string, nationality: string,
        dateOfBirth: Date, gender: string, dateOfExpiry: Date,
        mzr: string): MzrInput {
            return {
                PassportNo: passportNo,
                Nationality: nationality,
                DateOfBirth: dateOfBirth,
                Gender: gender,
                DateOfExpiry: dateOfExpiry,
                Mzr: mzr
            };
        }

    ValidateMzr(mzr: MzrInput): Promise<IMzrValidationResult[]> {
        return fetch(`api/MzrData/ValidateMzr`,
                {method: "post",
                 body: json(mzr)})
            .then(response => response.json())
            .then(data => {
                return data as IMzrValidationResult[];
            })
            .catch(err => {
                return [{ field: "error", status: "Error", message: err }];
            });
    }
}

export class MzrInput {
    PassportNo: string;
    Nationality: string;
    DateOfBirth: Date;
    Gender: string;
    DateOfExpiry: Date;
    Mzr: string;
}

export const Gender: any = {
    Male: "Male",
    Female: "Female"
};

export interface IMzrValidationResult {
    field: string;
    message: string;
    status: string;
}