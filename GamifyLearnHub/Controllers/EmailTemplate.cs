﻿namespace GamifyLearnHub.Controllers
{
    public static class EmailTemplate
    {
        public static string EmailBody(int userId)
        {
            string emailTemplate = "<!DOCTYPE html>\r\n    <html lang=\"en\">\r\n      <head>\r\n        <meta http-equiv=\"Content-Type\" content=\"text/html charset=UTF-8\" />\r\n        <title>Document</title>\r\n        <style>\r\n          @font-face {\r\n            font-family: \"Raleway\";\r\n            font-style: normal;\r\n            font-weight: 400;\r\n            src: url(\"https://raghadsacademy.com/wp-content/uploads/2021/temp/raleway/Raleway-Regular.ttf\")\r\n              format(\"truetype\");\r\n          }\r\n    \r\n          @font-face {\r\n            font-family: \"Raleway\";\r\n            font-style: normal;\r\n            font-weight: 600;\r\n            src: url(\"https://raghadsacademy.com/wp-content/uploads/2021/temp/raleway/Raleway-Medium.ttf\")\r\n              format(\"truetype\");\r\n          }\r\n    \r\n          @font-face {\r\n            font-family: \"Raleway\";\r\n            font-style: normal;\r\n            font-weight: bold;\r\n            src: url(\"https://raghadsacademy.com/wp-content/uploads/2021/temp/raleway/Raleway-SemiBold.ttf\")\r\n              format(\"truetype\");\r\n          }\r\n    \r\n          body {\r\n            margin: 0px;\r\n            padding: 0px;\r\n            font-family: Raleway, sans-serif;\r\n          }\r\n    \r\n          .table-1 {\r\n            width: 100%;\r\n            height: 1024px;\r\n            padding: 100px 100px;\r\n            background-color: #D1D1D1;\r\n          }\r\n    \r\n          .table-2 {\r\n            width: 600px;\r\n            height: 822px;\r\n            padding: 20.5px 0 24.7px;\r\n          }\r\n    \r\n          .table-img-1 {\r\n            width: 105.5px;\r\n            height: 18.8px;\r\n            margin: 0 247.7px 24.2px 246.7px;\r\n            object-fit: contain;\r\n          }\r\n    \r\n          .table-content {\r\n            width: 416px;\r\n            height: 419.8px;\r\n          }\r\n    \r\n          .table-img-2 {\r\n            width: 72px;\r\n            height: 72px;\r\n            padding: 7.5px 7.3px 7.5px 7.5px;\r\n            margin-bottom: 24.5px;\r\n          }\r\n    \r\n          .text-1 {\r\n            width: 100%;\r\n            margin: 0 0 12px;\r\n            font-size: 32px;\r\n            font-weight: bold;\r\n            font-stretch: normal;\r\n            font-style: normal;\r\n            line-height: 1.25;\r\n            letter-spacing: normal;\r\n            text-align: center;\r\n            color: #ffffff;\r\n          }\r\n    \r\n          .text-2 {\r\n            width: 100%;\r\n            margin: 12px 0 0;\r\n            font-size: 18px;\r\n            font-weight: 500;\r\n            font-stretch: normal;\r\n            font-style: normal;\r\n            line-height: 1.33;\r\n            letter-spacing: normal;\r\n            text-align: center;\r\n            color: #828282;\r\n          }\r\n    \r\n          .text-3 {\r\n            width: 100%;\r\n            margin: 0 0 32px;\r\n            font-size: 16px;\r\n            font-weight: normal;\r\n            font-stretch: normal;\r\n            font-style: normal;\r\n            line-height: 1.25;\r\n            letter-spacing: normal;\r\n            color: #ffffff;\r\n          }\r\n    \r\n          .text-4 {\r\n            width: 100%;\r\n            margin: 23.5px 0 0;\r\n            font-size: 16px;\r\n            font-weight: normal;\r\n            font-stretch: normal;\r\n            font-style: normal;\r\n            line-height: normal;\r\n            letter-spacing: normal;\r\n            color: #ffffff;\r\n          }\r\n    \r\n          .container-1 {\r\n            width: 290px;\r\n            height: 76.5px;\r\n          }\r\n    \r\n          .password-text {\r\n            width: 200px;\r\n            height: 16px;\r\n            margin-top: 0;\r\n            margin-bottom: 12.5px;\r\n            font-size: 14px;\r\n            font-weight: bold;\r\n            font-stretch: normal;\r\n            font-style: normal;\r\n            line-height: normal;\r\n            letter-spacing: normal;\r\n            text-align: center;\r\n            color: #ffa726;\r\n          }\r\n    \r\n          .table-border {\r\n            padding: 9.5px 64px;\r\n            border-radius: 8px;\r\n            border: solid 1px #ffa726;\r\n          }\r\n    \r\n          .password-contriner {\r\n            width: 162px;\r\n            height: 29px;\r\n            font-size: 24px;\r\n            font-weight: bold;\r\n            font-stretch: normal;\r\n            font-style: normal;\r\n            line-height: normal;\r\n            letter-spacing: normal;\r\n            text-align: center;\r\n            color: #ffffff;\r\n          }\r\n        </style>\r\n      </head>\r\n    \r\n      <body style=\"padding: 0; margin: 0\">\r\n        <table\r\n          role=\"presentation\"\r\n          border=\"0\"\r\n          cellpadding=\"0\"\r\n          cellspacing=\"0\"\r\n          class=\"table-1\"\r\n        >\r\n          <tr>\r\n            <td align=\"center\">\r\n              <table\r\n                role=\"presentation\"\r\n                border=\"0\"\r\n                cellpadding=\"0\"\r\n                cellspacing=\"0\"\r\n                bgcolor=\"#d7e2f3\"\r\n                class=\"table-2\"\r\n              >\r\n                <tr>\r\n                  <td align=\"center\">\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                      class=\"table-img-1\"\r\n                    >\r\n                      <tr>\r\n                        <td>\r\n                          /*<img\r\n                            src=\"https://i.ibb.co/rFPPvFx/logo-3.png\"\r\n                            alt=\"logo-image \"\r\n                          />\r\n     */                   </td>\r\n                      </tr>\r\n                    </table>\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                    >\r\n                      <tr>\r\n                        <td\r\n                          height=\"1\"\r\n                          bgcolor=\"#422b64\"\r\n                          style=\"\r\n                            border: none;\r\n                            border-bottom: 1px solid #422b64;\r\n                            font-size: 1px;\r\n                            line-height: 1px;\r\n                            width: 602px;\r\n                          \"\r\n                        ></td>\r\n                      </tr>\r\n                    </table>\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                      class=\"empty-table-1\"\r\n                    >\r\n                      <tr>\r\n                        <td\r\n                          style=\"width: 600px; height: 100px; margin: 0; padding: 0\"\r\n                        >\r\n                          <p\r\n                            style=\"\r\n                              width: 600px;\r\n                              height: 100px;\r\n                              margin: 0;\r\n                              padding: 0;\r\n                            \"\r\n                          ></p>\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                      class=\"table-content\"\r\n                    >\r\n                      <tr>\r\n                        <td align=\"center\">\r\n                          <table\r\n                            role=\"presentation\"\r\n                            border=\"0\"\r\n                            cellpadding=\"0\"\r\n                            cellspacing=\"0\"\r\n                            class=\"table-img-2\"\r\n                          >\r\n                            <tr>\r\n                              <td align=\"center\">\r\n                                <img\r\n                                  src=\"https://i.ibb.co/rFPPvFx/logo-3.png\"\r\n                                  alt=\"email-lock\"\r\n                                />\r\n                              </td>\r\n                            </tr>\r\n                          </table>\r\n    \r\n                          <table\r\n                            role=\"presentation\"\r\n                            border=\"0\"\r\n                            cellpadding=\"0\"\r\n                            cellspacing=\"0\"\r\n                            class=\"text-1\"\r\n                          >\r\n                            <tr>\r\n                              <td align=\"center\">Thank you </td>\r\n                            </tr>\r\n                          </table>\r\n    \r\n                          <table\r\n                            role=\"presentation\"\r\n                            border=\"0\"\r\n                            cellpadding=\"0\"\r\n                            cellspacing=\"0\"\r\n                            class=\"text-2\"\r\n                          >\r\n                            <tr>\r\n                              <td align=\"center\">\r\n                               Thank you for joining our family! We are thrilled to have you as a part of our community <br />reset\r\n                                your password\r\n                              </td>\r\n                            </tr>\r\n                          </table>\r\n                          <table\r\n                            role=\"presentation\"\r\n                            border=\"0\"\r\n                            cellpadding=\"0\"\r\n                            cellspacing=\"0\"\r\n                            class=\"empty-table-1\"\r\n                          >\r\n                            <tr>\r\n                              <td\r\n                                style=\"\r\n                                  width: 416px;\r\n                                  height: 40.8px;\r\n                                  margin: 0;\r\n                                  padding: 0;\r\n                                \"\r\n                              >\r\n                                <p\r\n                                  style=\"\r\n                                    height: 40.8px;\r\n                                    width: 416px;\r\n                                    margin: 0;\r\n                                    padding: 0;\r\n                                  \"\r\n                                ></p>\r\n                              </td>\r\n                            </tr>\r\n                          </table>\r\n                          <table\r\n                            role=\"presentation\"\r\n                            border=\"0\"\r\n                            cellpadding=\"0\"\r\n                            cellspacing=\"0\"\r\n                            class=\"container-1\"\r\n                          >\r\n                            <tr>\r\n                              <td align=\"center\">\r\n                                <table\r\n                                  role=\"presentation\"\r\n                                  border=\"0\"\r\n                                  cellpadding=\"0\"\r\n                                  cellspacing=\"0\"\r\n                                  class=\"password-text\"\r\n                                >\r\n                                  <tr>\r\n                                    <td align=\"center\">Best Regards</td>\r\n                                  </tr>\r\n                                </table>\r\n                                <table\r\n                                  role=\"presentation\"\r\n                                  border=\"0\"\r\n                                  cellpadding=\"0\"\r\n                                  cellspacing=\"0\"\r\n                                  class=\"table-border\"\r\n                                >\r\n                                  <tr>\r\n                                    <td align=\"center\">\r\n                                      <table\r\n                                        role=\"presentation\"\r\n                                        border=\"0\"\r\n                                        cellpadding=\"0\"\r\n                                        cellspacing=\"0\"\r\n                                        class=\"password-contriner\"\r\n                                      >\r\n                                        <tr>\r\n                                          <td align=\"center\">Gamify team</td>\r\n                                        </tr>\r\n                                      </table>\r\n                                    </td>\r\n                                  </tr>\r\n                                </table>\r\n                              </td>\r\n                            </tr>\r\n                          </table>\r\n                          <table\r\n                            role=\"presentation\"\r\n                            border=\"0\"\r\n                            cellpadding=\"0\"\r\n                            cellspacing=\"0\"\r\n                            class=\"empty-table-1\"\r\n                          >\r\n                            <tr>\r\n                              <td\r\n                                style=\"\r\n                                  width: 416px;\r\n                                  height: 40.5x;\r\n                                  margin: 0;\r\n                                  padding: 0;\r\n                                \"\r\n                              >\r\n                                <p\r\n                                  style=\"\r\n                                    width: 416px;\r\n                                    height: 40.5px;\r\n                                    margin: 0;\r\n                                    padding: 0;\r\n                                  \"\r\n                                ></p>\r\n                              </td>\r\n                            </tr>\r\n                          </table>\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                      class=\"empty-table-1\"\r\n                    >\r\n                      <tr>\r\n                        <td\r\n                          style=\"\r\n                            width: 600px;\r\n                            height: 100.5px;\r\n                            margin: 0;\r\n                            padding: 0;\r\n                          \"\r\n                        >\r\n                          <p\r\n                            style=\"\r\n                              width: 600px;\r\n                              height: 100.1px;\r\n                              margin: 0;\r\n                              padding: 0;\r\n                            \"\r\n                          ></p>\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                      class=\"text-3\"\r\n                    >\r\n                      <tr>\r\n                        <td align=\"center\">\r\n                          Please do not reply to this message. if you have any\r\n                          questions,<br />please\r\n                          <a\r\n                            href=\"mailto:mustafaalowisi@gmail.com\"\r\n                            target=\"_blank\"\r\n                            style=\"\r\n                              text-decoration: unset;\r\n                              color: #37c2cc;\r\n                              border-bottom: 1px solid #37c2cc;\r\n                              padding-bottom: 1px;\r\n                            \"\r\n                            rel=\"noopener\"\r\n                            >Contact us.</a\r\n                          >\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n    \r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                    >\r\n                      <tr>\r\n                        <td\r\n                          height=\"1\"\r\n                          bgcolor=\"#422b64\"\r\n                          style=\"\r\n                            border: none;\r\n                            border-bottom: 1px solid #422b64;\r\n                            font-size: 1px;\r\n                            line-height: 1px;\r\n                            width: 602px;\r\n                          \"\r\n                        ></td>\r\n                      </tr>\r\n                    </table>\r\n                    <table\r\n                      role=\"presentation\"\r\n                      border=\"0\"\r\n                      cellpadding=\"0\"\r\n                      cellspacing=\"0\"\r\n                      class=\"text-4\"\r\n                    >\r\n                      <tr>\r\n                        <td align=\"center\">\r\n                          © 2023 Gamfiy learning hub. All Right Reserved For Gamify Learning team.\r\n                        </td>\r\n                      </tr>\r\n                    </table>\r\n                  </td>\r\n                </tr>\r\n              </table>\r\n            </td>\r\n          </tr>\r\n        </table>\r\n      </body>\r\n    </html>";
            return emailTemplate;
        }
    }
}