﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlertControl.ascx.cs" Inherits="ODS_Software_Argentina_TFI.Controllers.AlertControl" %>


<div>
    <div id="dialogoverlay" style="display: none; height: 100vh"></div>
    <div id="dialogbox" class="slit-in-vertical" style="top: 100px">
        <div>
            <div id="dialogboxhead">
            </div>
            <div id="dialogboxbody">
            </div>
            <div id="dialogboxfoot">
                <button class="pure-material-button-contained active" onclick="customAlert.ok()">OK</button>
            </div>
        </div>
    </div>
</div>

<script>
    function CustomAlert() {
        let overlay = document.getElementById('dialogoverlay');
        let box = document.getElementById('dialogbox');
        let header = document.getElementById('dialogboxhead');
        let body = document.getElementById('dialogboxbody');
        let cssVars = document.querySelector(':root');

        show = function (message, title) {

            box.style.display = "block";
            overlay.style.display = "block";
            header.style.display = "block";

            if (typeof title === 'undefined') {
                header.style.display = 'none';
            } else {
                header.innerHTML = '<i class="fa fa-exclamation-circle" aria-hidden="true"></i> ' + title;
            }
            body.innerHTML = message;
        }

        this.alert = function (message, title) {
            cssVars.style.setProperty('--alert-color', '#4B90E3');
            cssVars.style.setProperty('--alert-color-header', '#5093E3');
            cssVars.style.setProperty('--alert-color-button', '#4B93E3');
            show(message, title);
        }

        this.error = function (message, title) {
            cssVars.style.setProperty('--alert-color', '#dc3545');
            cssVars.style.setProperty('--alert-color-header', '#de3845');
            cssVars.style.setProperty('--alert-color-button', '#dc3845');
            show(message, title);
        }

        this.ok = function () {
            document.getElementById('dialogbox').style.display = "none";
            document.getElementById('dialogoverlay').style.display = "none";
        }

    }

    let customAlert = new CustomAlert();
</script>
<style>
    /* ---------------Animation---------------- */
    :root {
        --alert-color: #4B90E3;
        --alert-color-button: #4B93E3;
        --alert-color-header: #5093E3;
    }

    .slit-in-vertical {
        -webkit-animation: slit-in-vertical 0.45s ease-out both;
        animation: slit-in-vertical 0.45s ease-out both;
    }

    @keyframes slit-in-vertical {
        0% {
            -webkit-transform: translateZ(-800px) rotateY(90deg);
            transform: translateZ(-800px) rotateY(90deg);
            opacity: 0;
        }

        54% {
            -webkit-transform: translateZ(-160px) rotateY(87deg);
            transform: translateZ(-160px) rotateY(87deg);
            opacity: 1;
        }

        100% {
            -webkit-transform: translateZ(0) rotateY(0);
            transform: translateZ(0) rotateY(0);
        }
    }

    /*---------------#region Alert--------------- */

    #dialogoverlay {
        display: none;
        opacity: .8;
        position: fixed;
        top: 0px;
        left: 0px;
        background: #707070;
        width: 100%;
        z-index: 10;
    }

    #dialogbox {
        display: none;
        position: absolute;
        background: var(--alert-color);
        border-radius: 7px;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.575);
        transition: 0.3s;
        width: 40%;
        z-index: 10;
        top: 0;
        left: 0;
        right: 0;
        margin: auto;
    }

        #dialogbox:hover {
            box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.911);
        }

    .container {
        padding: 2px 16px;
    }

    .pure-material-button-contained {
        position: relative;
        display: inline-block;
        box-sizing: border-box;
        border: none;
        border-radius: 4px;
        padding: 0 16px;
        min-width: 64px;
        height: 36px;
        vertical-align: middle;
        text-align: center;
        text-overflow: ellipsis;
        text-transform: uppercase;
        color: rgb(var(--pure-material-onprimary-rgb, 255, 255, 255));
        background-color: var(--alert-color-button);
        box-shadow: 0 3px 1px -2px rgba(0, 0, 0, 0.2), 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 1px 5px 0 rgba(0, 0, 0, 0.12);
        font-family: var(--pure-material-font, "Roboto", "Segoe UI", BlinkMacSystemFont, system-ui, -apple-system);
        font-size: 14px;
        font-weight: 500;
        line-height: 36px;
        overflow: hidden;
        outline: none;
        cursor: pointer;
        transition: box-shadow 0.2s;
    }

        .pure-material-button-contained::-moz-focus-inner {
            border: none;
        }

        /* ---------------Overlay--------------- */

        .pure-material-button-contained::before {
            content: "";
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background-color: rgb(var(--pure-material-onprimary-rgb, 255, 255, 255));
            opacity: 0;
            transition: opacity 0.2s;
        }

        /* Ripple */
        .pure-material-button-contained::after {
            content: "";
            position: absolute;
            left: 50%;
            top: 50%;
            border-radius: 50%;
            padding: 50%;
            width: 32px; /* Safari */
            height: 32px; /* Safari */
            background-color: rgb(var(--pure-material-onprimary-rgb, 255, 255, 255));
            opacity: 0;
            transform: translate(-50%, -50%) scale(1);
            transition: opacity 1s, transform 0.5s;
        }

        /* Hover, Focus */
        .pure-material-button-contained:hover,
        .pure-material-button-contained:focus {
            box-shadow: 0 2px 4px -1px rgba(0, 0, 0, 0.2), 0 4px 5px 0 rgba(0, 0, 0, 0.14), 0 1px 10px 0 rgba(0, 0, 0, 0.12);
        }

            .pure-material-button-contained:hover::before {
                opacity: 0.08;
            }

            .pure-material-button-contained:focus::before {
                opacity: 0.24;
            }

            .pure-material-button-contained:hover:focus::before {
                opacity: 0.3;
            }

        /* Active */
        .pure-material-button-contained:active {
            box-shadow: 0 5px 5px -3px rgba(0, 0, 0, 0.2), 0 8px 10px 1px rgba(0, 0, 0, 0.14), 0 3px 14px 2px rgba(0, 0, 0, 0.12);
        }

            .pure-material-button-contained:active::after {
                opacity: 0.32;
                transform: translate(-50%, -50%) scale(0);
                transition: transform 0s;
            }

        /* Disabled */
        .pure-material-button-contained:disabled {
            color: rgba(var(--pure-material-onsurface-rgb, 0, 0, 0), 0.38);
            background-color: rgba(var(--pure-material-onsurface-rgb, 0, 0, 0), 0.12);
            box-shadow: none;
            cursor: initial;
        }

            .pure-material-button-contained:disabled::before {
                opacity: 0;
            }

            .pure-material-button-contained:disabled::after {
                opacity: 0;
            }

    #dialogbox > div {
        background: #FFF;
        margin: 8px;
    }

        #dialogbox > div > #dialogboxhead {
            background: var(--alert-color-header);
            font-size: 19px;
            padding: 10px;
            color: rgb(255, 255, 255);
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }

        #dialogbox > div > #dialogboxbody {
            background: var(--alert-color);
            padding: 20px;
            color: #FFF;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }

        #dialogbox > div > #dialogboxfoot {
            background: var(--alert-color);
            padding: 10px;
            text-align: right;
        }
</style>