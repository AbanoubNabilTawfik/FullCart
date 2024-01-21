export enum buildModeConfig {
  Local,
  Dev,
  Prod,
}

var baseUrl = "";

export const buildMode: buildModeConfig =
  buildModeConfig.Local as buildModeConfig;

if (buildMode == buildModeConfig.Local) {
  baseUrl = "https://localhost:7080";
} else if (buildMode == buildModeConfig.Dev) {
  baseUrl = "https://localhost:7080";
} else {
  baseUrl = "https://localhost:7080";
}

export const BaseURL = baseUrl;