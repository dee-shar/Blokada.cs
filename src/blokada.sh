#!/bin/bash

api="https://api.blocka.net/v2"
user_agent="blokada/23.1.10 (android-28 six release x86_64 blackshark gracelte touch api compatible)"

function get_account() {
	response=$(curl --request POST \
		--url "$api/account" \
		--user-agent "$user_agent")
	if [ -n $(jq -r ".account.id" <<< "$response") ]; then
		account_id=$(jq -r ".account.id" <<< "$response")
	fi
	echo $response
}

function get_devices() {
	curl --request GET \
		--url "$api/device?account_id=$account_id" \
		--user-agent "$user_agent"
}

function get_devices() {
	curl --request GET \
		--url "$api/device?account_id=$account_id" \
		--user-agent "$user_agent"
}

function get_stats() {
	curl --request GET \
		--url "$api/stats?account_id=$account_id" \
		--user-agent "$user_agent"
}

function get_activity() {
	curl --request GET \
		--url "$api/activity?account_id=$account_id" \
		--user-agent "$user_agent"
}

function get_list() {
	curl --request GET \
		--url "$api/list?account_id=$account_id" \
		--user-agent "$user_agent"
}

function get_custom_list() {
	curl --request GET \
		--url "$api/customlist?account_id=$account_id" \
		--user-agent "$user_agent"
}

function get_leases() {
	curl --request GET \
		--url "$api/lease?account_id=$account_id" \
		--user-agent "$user_agent"
}
