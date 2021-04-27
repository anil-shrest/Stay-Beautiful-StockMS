<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StayBeautifulSMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body">
        <div class="container">
            <nav class="navbar">
                <div class="nav_icon" onclick="toggleSidebar()">
                    <i class="fa fa-bars" aria-hidden="true"></i>
                </div>
                <div class="navbar__left">
                    <a href="#">Subscribers</a>
                    <a href="#">Video Management</a>
                    <a class="active_link" href="#">Admin</a>
                </div>
                <div class="navbar__right">
                    <a href="#">
                        <i class="fa fa-search" aria-hidden="true"></i>
                    </a>
                    <a href="#">
                        <i class="fa fa-clock-o" aria-hidden="true"></i>
                    </a>
                    <a href="#">
                        <img width="30" src="assets/avatar.svg" alt="" />
                        <!-- <i class="fa fa-user-circle-o" aria-hidden="true"></i> -->
                    </a>
                </div>
            </nav>

            <main>
                <div class="main__container">
                    <!-- MAIN TITLE STARTS HERE -->

                    <div class="main__title">
                        <img src="assets/hello.svg" alt="" />
                        <div class="main__greeting">
                            <h1>Stay Beautiful Management System</h1>
                            <p>Admin Dashboard</p>
                        </div>
                    </div>

                    <!-- MAIN TITLE ENDS HERE -->

                    <!-- MAIN CARDS STARTS HERE -->
                    <div class="main__cards">
                        <div class="card">
                            <i
                                class="fa fa-user-o fa-2x text-lightblue"
                                aria-hidden="true"></i>
                            <div class="card_inner">
                                <p class="text-primary-p">Number of Subscribers</p>
                                <span class="font-bold text-title">578</span>
                            </div>
                        </div>

                        <div class="card">
                            <i class="fa fa-calendar fa-2x text-red" aria-hidden="true"></i>
                            <div class="card_inner">
                                <p class="text-primary-p">Times of Watching</p>
                                <span class="font-bold text-title">2467</span>
                            </div>
                        </div>

                        <div class="card">
                            <i
                                class="fa fa-video-camera fa-2x text-yellow"
                                aria-hidden="true"></i>
                            <div class="card_inner">
                                <p class="text-primary-p">Number of Videos</p>
                                <span class="font-bold text-title">340</span>
                            </div>
                        </div>

                        <div class="card">
                            <i
                                class="fa fa-thumbs-up fa-2x text-green"
                                aria-hidden="true"></i>
                            <div class="card_inner">
                                <p class="text-primary-p">Number of Likes</p>
                                <span class="font-bold text-title">645</span>
                            </div>
                        </div>
                    </div>
                    <!-- MAIN CARDS ENDS HERE -->

                    <!-- CHARTS STARTS HERE -->
                    <div class="charts">
                        <div class="charts__left">
                            <div class="charts__left__title">
                                <div>
                                    <h1>Daily Reports</h1>
                                    <p>Cupertino, California, USA</p>
                                </div>
                                <i class="fa fa-usd" aria-hidden="true"></i>
                            </div>
                            <div id="apex1"></div>
                        </div>

                        <div class="charts__right">
                            <div class="charts__right__title">
                                <div>
                                    <h1>Stats Reports</h1>
                                    <p>Cupertino, Kathmandu, Nepal</p>
                                </div>
                                <i class="fa fa-usd" aria-hidden="true"></i>
                            </div>

                            <div class="charts__right__cards">
                                <div class="card1">
                                    <h1>Brands</h1>
                                    <p id ="brands" runat="server" class="stats"></p>
                                </div>

                                <div class="card2">
                                    <h1>Items</h1>
                                    <p id ="items" runat="server" class="stats"></p>
                                </div>

                                <div class="card3">
                                    <h1>Purchases</h1>
                                    <p id ="purchases" runat="server" class="stats"></p>
                                </div>

                                <div class="card4">
                                    <h1>Customers</h1>
                                    <p id ="customers" runat="server" class="stats"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- CHARTS ENDS HERE -->
                </div>
            </main>


        </div>

        <script src="https://cdn.jsdelivr.net/npm/apexcharts"></script>
        <script src="Scripts/dashboard.js"></script>
    </div>
    </div>
    <%--</html>--%>
</asp:Content>
