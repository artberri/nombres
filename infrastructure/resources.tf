resource "azurerm_resource_group" "nombres" {
    name     = "nombres"
    location = "${var.arm_region}"
}

resource "azurerm_application_insights" "nombres" {
    name                = "nombres-appinsights"
    location            = "${azurerm_resource_group.nombres.location}"
    resource_group_name = "${azurerm_resource_group.nombres.name}"
    application_type    = "Web"

    tags {
        project = "Nombres"
    }
}

resource "azurerm_app_service_plan" "nombres" {
    name                = "nombres-appserviceplan"
    location            = "${azurerm_resource_group.nombres.location}"
    resource_group_name = "${azurerm_resource_group.nombres.name}"
    kind                = "Linux"

    properties {
        reserved = true
    }

    sku {
        tier = "Standard"
        size = "S1"
    }
}

resource "azurerm_template_deployment" "nombresapp" {
    name = "nombres-web-app"
    resource_group_name = "${azurerm_resource_group.nombres.name}"

    template_body = <<DEPLOY
{
    "$schema": "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
        "app_service_plan_id": {
            "type": "string",
            "metadata": {
                "description": "App Service Plan ID"
            }
        },
        "name": {
            "type": "string",
            "metadata": {
                "description": "App Name"
            }
        },
        "slot_name": {
            "type": "string",
            "metadata": {
                "description": "Staging Slot Name"
            }
        },
        "image": {
            "type": "string",
            "metadata": {
                "description": "Docker image"
            }
        },
        "custom_domain": {
            "type": "string",
            "metadata": {
                "description": "Custom domain"
            }
        }
    },
    "variables": {
    },
    "resources": [
        {
            "type": "Microsoft.Web/sites",
            "kind": "app,linux,container",
            "name": "[parameters('name')]",
            "apiVersion": "2016-08-01",
            "location": "[resourceGroup().location]",
            "properties": {
                "name": "[parameters('name')]",
                "serverFarmId": "[parameters('app_service_plan_id')]",
                "siteConfig": {
                    "alwaysOn": true,
                    "http20Enabled": true,
                    "httpsOnly": true,
                    "appSettings": [
                        {
                            "name": "WEBSITES_ENABLE_APP_SERVICE_STORAGE",
                            "value": "false"
                        },
                        {
                            "name": "WEBSITES_PORT",
                            "value": "5000"
                        }
                    ],
                    "linuxFxVersion": "[concat('DOCKER|', parameters('image'))]"
                }
            },
            "resources": [
                {
                    "type": "Microsoft.Web/Sites/Slots",
                    "name": "[concat(parameters('name'), '/', parameters('slot_name'))]",
                    "apiVersion": "2015-04-01",
                    "location": "[resourceGroup().location]",
                    "properties": {},
                    "resources": [],
                    "dependsOn": [
                        "[resourceId('Microsoft.Web/Sites', parameters('name'))]"
                    ]
                }
            ]
        }
    ]
}
DEPLOY

    parameters {
        name                = "nombresapp"
        image               = "artberri/nombres:latest"
        slot_name           = "staging"
        custom_domain       = "nombres.berriart.com"
        app_service_plan_id = "${azurerm_app_service_plan.nombres.id}"
    }

    deployment_mode = "Incremental"
}
