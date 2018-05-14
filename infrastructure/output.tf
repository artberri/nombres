output "app_insights_id" {
    value = "${azurerm_application_insights.nombres.app_id}"
}

output "app_insights_instrumentation_key" {
    value = "${azurerm_application_insights.nombres.instrumentation_key}"
}

