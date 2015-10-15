var PageValidator = {
    OtherOption: "other (please specify)",

    OnSiblingRadioChanged: function (rdoObject) {
        $('#siblingContact').hide();
        if ($('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')) {
            $('#ctl00_Content_txtSiblingFirstName').removeAttr('disabled');
            $('#ctl00_Content_txtSiblingLastName').removeAttr('disabled');
        } else if ($('#ctl00_Content_rdolistSiblingAttended_1').is(':checked') || $('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
            $('#ctl00_Content_txtSiblingFirstName').attr('disabled', true);
            $('#ctl00_Content_txtSiblingLastName').attr('disabled', true);
            if ($('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
                $('#siblingContact').show();
            }
        }
    },

    OnFirstTimerChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            $('#ctl00_Content_divTaste :input').removeAttr('disabled');
        } else {
            $('#ctl00_Content_divTaste :input').attr('disabled', true);
        }
    },

    OnSchoolDropDownChange: function (ddlObject) {
        if ($('#ctl00_Content_rdoSchoolType_2').is(':checked')) {
            $('#ctl00_Content_txtSchoolName').attr('disabled', true);
        } else {
            $('#ctl00_Content_txtSchoolName').removeAttr('disabled');
        }
    },

    OnSecondarySchoolRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoSecondarySchoolYes').is(':checked')) {
            $("#6a").show();
        } else {
            $("#6a").hide();
        }
    },

    OnSecondarySchoolDropDownChange: function (ddlObject) {
        var $ddl = $('#ctl00_Content_ddlSecondarySchool'),
            $txt = $('#ctl00_Content_txtSecondarySchool');

        if ($ddl.val() == "Other") {
            $txt.attr('disabled', false);
        } else {
            $txt.attr('disabled', true);
        }
    },

    OnSynagogueCheckboxChange: function (chkboxObject) {
        var $ddlSynagogue = $('#ctl00_Content_ddlSynagogue');

        if ($(chkboxObject).is(':checked')) {
            $ddlSynagogue.removeAttr('disabled');
            PageValidator.OnSynagogueDropDownChange(null);
            PageValidator.ToggleTypeWhoInSynagogue(true);
        } else {
            $ddlSynagogue.attr('disabled', true);
            $('#ctl00_Content_txtOtherSynagogue').attr('disabled', true);
            PageValidator.ToggleTypeWhoInSynagogue(false)
        }
    },

    ToggleTypeWhoInSynagogue: function (isEnable) {
        var $rdoCongregant = $('#ctl00_Content_rdoCongregant'),
            $rdoNoOne = $('#ctl00_Content_rdoNoOne');

        if (isEnable) {
            $rdoCongregant.removeAttr('disabled');
            $rdoNoOne.removeAttr('disabled');
        } else {
            $rdoCongregant.attr('disabled', true);
            $rdoNoOne.attr('disabled', true);
        }
        PageValidator.ToggleWhoInSyangogue(isEnable);
    },

    ToggleWhoInSyangogue: function (isEnable) {
        var $ddlWho = $('#ctl00_Content_ddlWho'),
            $txtWhoInSynagogue = $('#ctl00_Content_txtWhoInSynagogue');

        if (isEnable) {
            $ddlWho.removeAttr('disabled');
            PageValidator.OnWhoInSynagogueDropDownChange(null);
        } else {
            $ddlWho.attr('disabled', true);
            $txtWhoInSynagogue.attr('disabled', true);
        }
    },

    OnWhoInSynagogueDropDownChange: function (ddlObject) {
        var $txtWhoInSynagogue = $('#ctl00_Content_txtWhoInSynagogue');

        if ($('#ctl00_Content_ddlWho>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $txtWhoInSynagogue.removeAttr('disabled');
        } else {
            $txtWhoInSynagogue.attr('disabled', true);
        }
    },

    OnJCCChekboxChange: function (chkboxObject) {
        var $ddlJCC = $('#ctl00_Content_ddlJCC'),
            $txtOtherJCC = $('#ctl00_Content_txtOtherJCC')

        if ($(chkboxObject).is(':checked')) {
            $ddlJCC.removeAttr('disabled');
            PageValidator.OnJCCDropDownChange(null);
        } else {
            $ddlJCC.attr('disabled', true);
            $txtOtherJCC.attr('disabled', true);
        }
    },

    OnOtherChekboxChange: function (chkboxObject) {
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC');

        if ($(chkboxObject).is(':checked')) {
            $chkSynagogue.attr('disabled', true);
            $chkSynagogue.attr('checked', false);

            $chkJCC.attr('disabled', true);
            $chkJCC.attr('checked', false);
        } else {
            // Uncheck the None of Above box
            $chkSynagogue.removeAttr('disabled');
            $chkJCC.removeAttr('disabled');
        }

        PageValidator.OnSynagogueCheckboxChange($chkSynagogue);
        PageValidator.OnJCCChekboxChange($chkJCC);
    },

    OnSynagogueDropDownChange: function (ddlObject) {
        var $txtOtherSynagogue = $('#ctl00_Content_txtOtherSynagogue'),
            $ddlWho = $('#ctl00_Content_ddlWho');

        if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $txtOtherSynagogue.removeAttr('disabled');
        } else {
            $txtOtherSynagogue.attr('disabled', true);

            // 2013-10-07 Toronto has special rule depends on selecte Synagogue
            if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Beth Tzedec Congregation") {
                PageValidator.ToggleddlWhoNames("26");
            } else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "City Shul") {
                PageValidator.ToggleddlWhoNames("27");
            } else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Holy Blossom Temple") {
                PageValidator.ToggleddlWhoNames("28");
            } else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Shaarei Shomayim Congregation") {
                PageValidator.ToggleddlWhoNames("29");
            } else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Shaarei Tefillah Congregation") {
                PageValidator.ToggleddlWhoNames("30");
            } else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Temple Sinai Congregation") {
                PageValidator.ToggleddlWhoNames("31");
            } else {
                PageValidator.ToggleddlWhoNames("-1");
            }

            //if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Beth Tzedec Congregation") {
            //    PageValidator.ToggleddlWhoNames("14");
            //} else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "City Shul") {
            //    PageValidator.ToggleddlWhoNames("15");
            //} else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Holy Blossom Temple") {
            //    PageValidator.ToggleddlWhoNames("16");
            //} else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Shaarei Shomayim Congregation") {
            //    PageValidator.ToggleddlWhoNames("17");
            //} else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Shaarei Tefillah Congregation") {
            //    PageValidator.ToggleddlWhoNames("18");
            //} else if ($('#ctl00_Content_ddlSynagogue>option:selected').text() === "Temple Sinai Congregation") {
            //    PageValidator.ToggleddlWhoNames("19");
            //} else {
            //    PageValidator.ToggleddlWhoNames("-1");
            //}
        }
    },

    ToggleddlWhoNames: function(idtoShow) {
        for (var i = 14; i < 20; i++) {
            // 2013-10-08 IE cannot understand option selector, so I have to comment out the single line below, and use the complex logic
            //$("#ctl00_Content_ddlWho option[value='" + i.toString() + "']").hide();

            //To hide elements
            $("#ctl00_Content_ddlWho option").each(function (index, val) {
                if ($(this).is('option') && (!$(this).parent().is('span'))) {

                    if ($(this).val() == i.toString())
                        $(this).wrap((navigator.appName == 'Microsoft Internet Explorer') ? '<span>' : null).hide();
                    //else
                    //    $(this).wrap((navigator.appName == 'Microsoft Internet Explorer') ? '<span>' : null);
                }

            });
        }
        // 2013-10-08 IE cannot understand option selector, so I have to comment out the single line below, and use the complex logic
        //$("#ctl00_Content_ddlWho option[value='" + idtoShow + "']").show();

        //To show elements
        $("#ctl00_Content_ddlWho option").each(function (index, val) {
            if ($(this).val() == idtoShow.toString()) {
                if (navigator.appName == 'Microsoft Internet Explorer') {
                    if (this.nodeName.toUpperCase() === 'OPTION') {
                        var span = $(this).parent();
                        var opt = this;
                        if ($(this).parent().is('span')) {

                            $(opt).show();
                            $(span).replaceWith(opt);
                        }
                    }
                } else {
                    $(this).show(); //all other browsers use standard .show()
                }
            }
        });
    },

    OnJCCDropDownChange: function (ddlObject) {
        var $txtOtherJCC = $('#ctl00_Content_txtOtherJCC');

        if ($('#ctl00_Content_ddlJCC>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
            $txtOtherJCC.removeAttr('disabled');
        } else {
            $txtOtherJCC.attr('disabled', true);
        }
    },

    OnWhoRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoCongregant').is(':checked')) {
            PageValidator.ToggleWhoInSyangogue(true);
        } else {
            PageValidator.ToggleWhoInSyangogue(false);
        }
    },

    OnYouthMovementRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoMemberOfYouthYes').is(':checked')) {
            $('#ctl00_Content_txtMemberOfYouth').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtMemberOfYouth').attr('disabled', true);
        }
    },

    OnParticipateMarchLivingCheckboxChange: function (chkboxObject) {
        if (chkboxObject.id === "ctl00_Content_rdolistParticipateMarchLiving_3") {
            if ($('#ctl00_Content_rdolistParticipateMarchLiving_3').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_2').attr('disabled', true);

                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateMarchLiving_2').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateMarchLiving_2').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateMarchLiving_0") {
            if ($('#ctl00_Content_rdolistParticipateMarchLiving_0').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateMarchLiving_1').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateMarchLiving_1") {
            if ($('#ctl00_Content_rdolistParticipateMarchLiving_1').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateMarchLiving_0').removeAttr('disabled');
            }
        }
    },

    OnParticipateTaglitCheckboxChange: function (chkboxObject) {
        if (chkboxObject.id === "ctl00_Content_rdolistParticipateTaglit_3") {
            if ($('#ctl00_Content_rdolistParticipateTaglit_3').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_2').attr('disabled', true);

                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('checked', false);
                $('#ctl00_Content_rdolistParticipateTaglit_2').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateTaglit_0').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateTaglit_1').removeAttr('disabled');
                $('#ctl00_Content_rdolistParticipateTaglit_2').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateTaglit_0") {
            if ($('#ctl00_Content_rdolistParticipateTaglit_0').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_1').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateTaglit_1').removeAttr('disabled');
            }
        } else if (chkboxObject.id === "ctl00_Content_rdolistParticipateTaglit_1") {
            if ($('#ctl00_Content_rdolistParticipateTaglit_1').is(':checked')) {
                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('disabled', true);
                $('#ctl00_Content_rdolistParticipateTaglit_0').attr('checked', false);
            } else {
                $('#ctl00_Content_rdolistParticipateTaglit_0').removeAttr('disabled');
            }
        }
    },

    OnBeenToIsraelRadioChange: function (rdoObject) {
        if ($('#ctl00_Content_rdoBeenToIsraelYes').is(':checked')) {
            $('#ctl00_Content_txtBeenToIsrael').removeAttr('disabled');
        } else {
            $('#ctl00_Content_txtBeenToIsrael').attr('disabled', true);
        }
    },

    OnSubmitClick: function (sender, args) {
        // Make sure everything must be selected
        var errorMsg = $(sender)[0];
        errorMsg.innerHTML = "";

        // First Timer camper or not
        if (!$('#ctl00_Content_rdoFirstTimerYes').is(':checked') && !$('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 1</li></ul>";
        }

        if ($('#ctl00_Content_rdoFirstTimerNo').is(':checked')) {
            if (!$('#ctl00_Content_rdoTasteOfCampYes').is(':checked') && !$('#ctl00_Content_rdoTasteOfCampNo').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Please answer Question No. 1 - Taste of Camp.</li></ul>";
            }
        }

        // Siblings
        if (!$('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')
            && !$('#ctl00_Content_rdolistSiblingAttended_1').is(':checked')
            && !$('#ctl00_Content_rdolistSiblingAttended_2').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer question No. 2</li></ul>";
        }

        if ($('#ctl00_Content_rdolistSiblingAttended_0').is(':checked')) {
            if ($('#ctl00_Content_txtSiblingFirstName').val() === "" || $('#ctl00_Content_txtSiblingLastName').val() === "") {
                errorMsg.innerHTML += "<ul><li>Please answer question No. 3</li></ul>";
            }
        }
        
        // Grade
        if ($('#ctl00_Content_ddlGrade>option:selected').val() === "0") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 4</li></ul>";
        }

        // School Type
        if (!$('#ctl00_Content_rdoSchoolType_0').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_1').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_2').is(':checked') &&
            !$('#ctl00_Content_rdoSchoolType_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 5</li></ul>";
        }
        
        // School Name
        if (!$('#ctl00_Content_rdoSchoolType_2').is(':checked') && $('#ctl00_Content_txtSchoolName').val() === "") {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 6</li></ul>";
        }

        // Synagogue/JCC
        var $chkSynagogue = $('#ctl00_Content_chkSynagogue'),
            $chkJCC = $('#ctl00_Content_chkJCC'),
            $chkNo = $('#ctl00_Content_chkNo'),
            $rdoCongregant = $('#ctl00_Content_rdoCongregant');

        if (!$chkSynagogue.is(':checked') && !$chkJCC.is(':checked') && !$chkNo.is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 7 - at least check one of three options</li></ul>";
        }

        // Synagogue - when it's checked, some error checking
        if ($chkSynagogue.is(':checked') && !$chkSynagogue.is(':disabled')) {
            if ($('#ctl00_Content_ddlSynagogue>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 7 - please select one synagogue.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSynagogue>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 7 - please enter the synagogue name.</li></ul>";
                }
            }

            if (!$rdoCongregant.is(':checked') && !$('#ctl00_Content_rdoNoOne').is(':checked')) {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 7a - please select who did you speak to in your synagogue.</li></ul>";
            }

            if ($rdoCongregant.is(':checked') && $('#ctl00_Content_ddlWho>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 7a - please select one person from your synagogue.</li></ul>";
            }

            if ($rdoCongregant.is(':checked') && $('#ctl00_Content_ddlWho>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtWhoInSynagogue').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 7a - please enter the person's name from your synagogue.</li></ul>";
                }
            }
        }

        // JCC - when it's checked, some error checking
        if ($chkJCC.is(':checked') && !$chkJCC.is(':disabled')) {
            if ($('#ctl00_Content_ddlJCC>option:selected').val() === "0") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 7 - please select one JCC.</li></ul>";
            }

            if ($('#ctl00_Content_ddlJCC>option:selected').text().toLowerCase() === SJValidator.OtherOption) {
                if ($('#ctl00_Content_txtOtherJCC').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 7 - please enter the JCC name.</li></ul>";
                }
            }
        }

        // Secondary School
        if (!$('#ctl00_Content_rdoSecondarySchoolYes').is(':checked') && !$('#ctl00_Content_rdoSecondarySchoolNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 8</li></ul>";
        }

        if ($('#ctl00_Content_rdoSecondarySchoolYes').is(':checked')) {
            if ($('#ctl00_Content_ddlSecondarySchool>option:selected').text() === "-- Select --") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 8a - please select a seconadary school.</li></ul>";
            }

            if ($('#ctl00_Content_ddlSecondarySchool>option:selected').text().toLowerCase() === "other") {
                if ($('#ctl00_Content_txtSecondarySchool').val() === "") {
                    errorMsg.innerHTML += "<ul><li>Error in Question No. 8a - please enter the secondary school name.</li></ul>";
                }
            }
        }

        // Any memebers are Youth Movement?
        if (!$('#ctl00_Content_rdoMemberOfYouthYes').is(':checked') && !$('#ctl00_Content_rdoMemberOfYouthNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 9</li></ul>";
        }

        if ($('#ctl00_Content_rdoMemberOfYouthYes').is(':checked')) {
            if ($('#ctl00_Content_txtMemberOfYouth').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 9 - please enter your family member.</li></ul>";
            }
        }

        // Participated in March Living?
        if (!$('#ctl00_Content_rdolistParticipateMarchLiving_0').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateMarchLiving_1').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateMarchLiving_2').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateMarchLiving_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 10</li></ul>";
        }

        // Participated in Taglit?
        if (!$('#ctl00_Content_rdolistParticipateTaglit_0').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateTaglit_1').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateTaglit_2').is(':checked') &&
            !$('#ctl00_Content_rdolistParticipateTaglit_3').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 11</li></ul>";
        }

        // been to Israel?
        if (!$('#ctl00_Content_rdoBeenToIsraelYes').is(':checked') && !$('#ctl00_Content_rdoBeenToIsraelNo').is(':checked')) {
            errorMsg.innerHTML += "<ul><li>Please answer Question No. 12</li></ul>";
        }

        if ($('#ctl00_Content_rdoBeenToIsraelYes').is(':checked')) {
            if ($('#ctl00_Content_txtBeenToIsrael').val() === "") {
                errorMsg.innerHTML += "<ul><li>Error in Question No. 12 - please enter your family member.</li></ul>";
            }
        }

        if (errorMsg.innerHTML === "") {
            args.IsValid = true;
        } else {
            args.IsValid = false;
        }
        return;
    }
};

$(function () {
    PageValidator.OnSynagogueCheckboxChange($('#ctl00_Content_chkSynagogue'));
    PageValidator.OnJCCChekboxChange($('#ctl00_Content_chkJCC'));
    PageValidator.OnOtherChekboxChange($('#ctl00_Content_chkNo'));
    PageValidator.OnFirstTimerChange(null);
    PageValidator.OnSiblingRadioChanged(null);
    PageValidator.OnYouthMovementRadioChange(null);
    PageValidator.OnSecondarySchoolRadioChange(null);
    PageValidator.OnSecondarySchoolDropDownChange(null);
    PageValidator.OnBeenToIsraelRadioChange(null);
    PageValidator.OnSynagogueDropDownChange(null);

    if ($('#ctl00_Content_rdolistParticipateMarchLiving_3').is(':checked')) {
        PageValidator.OnParticipateMarchLivingCheckboxChange($('#ctl00_Content_rdolistParticipateMarchLiving_3')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateMarchLiving_0').is(':checked')) {
        PageValidator.OnParticipateMarchLivingCheckboxChange($('#ctl00_Content_rdolistParticipateMarchLiving_0')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateMarchLiving_1').is(':checked')) {
        PageValidator.OnParticipateMarchLivingCheckboxChange($('#ctl00_Content_rdolistParticipateMarchLiving_1')[0]);
    }

    if ($('#ctl00_Content_rdolistParticipateTaglit_3').is(':checked')) {
        PageValidator.OnParticipateTaglitCheckboxChange($('#ctl00_Content_rdolistParticipateTaglit_3')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateTaglit_0').is(':checked')) {
        PageValidator.OnParticipateTaglitCheckboxChange($('#ctl00_Content_rdolistParticipateTaglit_0')[0]);
    } else if ($('#ctl00_Content_rdolistParticipateTaglit_1').is(':checked')) {
        PageValidator.OnParticipateTaglitCheckboxChange($('#ctl00_Content_rdolistParticipateTaglit_1')[0]);
    }

})